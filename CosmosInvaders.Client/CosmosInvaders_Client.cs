using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CosmosInvaders.Library;
using System.Drawing.Drawing2D;
using Newtonsoft.Json;
using CosmosInvaders.Client.Interpreter;
using CosmosInvaders.Client.Iterator;


namespace CosmosInvaders.Client
{
    public partial class CosmosInvaders_Client : Form
    {
        private Game _instance { get; set; }
        private static HttpClient client = new HttpClient();
        private IDraw GameDraw { get; set; }
        private bool Connected { get; set; } = false;
        private WSConnection ChatHub { get; set; }
        public CommandParser Parser { get; private set; }

        public CosmosInvaders_Client()
        {
            InitializeComponent();
            GameDraw = new GameDraw(splitContainer1);

            client.BaseAddress = new Uri("http://localhost:54973/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            _instance = Game.Instance;
            VehiclesDropDown.DataSource = new List<string>
            {
                "",
                "Bicycle",
                "Motorbike",
                "Quad",
                "RaceCar",
                "Truck",
                "Jeep"
            };

            ChatHub = new WSConnection(_instance, GameDraw);
            ChatHub.GetUserName += () => UsernameTextBox.Text;
            ChatHub.GetUserFamily += () => getFamilyFromSelection(VehiclesDropDown.SelectedValue.ToString());
            ChatHub.GetUserVehicle += () => VehiclesDropDown.SelectedValue.ToString();
            ChatHub.SetSpeed += (speed) => Invoker(SpeedValue, speed);
            ChatHub.SetDirection += (direction) => Invoker(DirectionValue, direction);
            ChatHub.SetLog += (text) => Invoker(OutputLog, text);
            ChatHub.SetPosLog += (text) => Invoker(positionSaves, text);
            ChatHub.SetGameLog += (text) => InvokerAppend(logBox, text);
            ChatHub.SetMessage += (text) => InvokerAppendMessage(messageBox, text);

            //GameDraw.DrawMap();
            splitContainer1.Panel1.BackgroundImage = new Bitmap(@"..\..\Map.png");
            base.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            this.KeyPreview = true;
            Parser = new CommandParser();
            Parser.Reset += (a) => ChatHub.Reset(a);
            Parser.GetName += (a) => ChatHub.GetName(a);
        }

        private void Invoker(dynamic field, string text)
        {
            Action action = () => field.Text = text;
            field.Invoke(action, null);
        }

        private void InvokerAppend(dynamic field, string text)
        {
            Action action = () => field.Text += text + "\n";
            field.Invoke(action, null);
        }

        private void InvokerAppendMessage(dynamic field, Tuple<string,string> text)
        {
            Action action1 = () => field.AppendText(text.Item1);
            field.Invoke(action1, null);

            Action action = () => field.SelectedRtf = text.Item2;
            field.Invoke(action, null);

            Action action2 = () => field.AppendText("\n");
            field.Invoke(action2, null);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

            g.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.Black)), p.DisplayRectangle);

            Point[] points = new Point[4];

            points[0] = new Point(0, 0);
            points[1] = new Point(0, p.Height);
            points[2] = new Point(p.Width, p.Height);
            points[3] = new Point(p.Width, 0);

            Brush brush = new SolidBrush(Color.DarkGreen);

            g.FillPolygon(brush, points);

            g.DrawRectangle(
                new Pen(Brushes.Gray, 90),
                new Rectangle(135, 80, 500, 400)
                );

            g.DrawLine(
                new Pen(Brushes.White, 10),
                new Point(90, 280),
                new Point(180, 280)
                );

            Rectangle lightL = new Rectangle(52, 52, 1, 1);
            Rectangle lightR = new Rectangle(58, 52, 1, 1);
            Rectangle rect = new Rectangle(50, 50, 10, 15);

            g.FillRectangle(Brushes.Black, rect);
            g.FillRectangle(Brushes.Yellow, lightL);
            g.FillRectangle(Brushes.Yellow, lightR);
            g.DrawRectangle(Pens.Black, rect);
            g.DrawRectangle(Pens.Yellow, lightL);
            g.DrawRectangle(Pens.Yellow, lightR);
        }
        private string getFamilyFromSelection(string vehicle)
        {
            string family = "";
            // Kreipimasis i api
            switch (VehiclesDropDown.SelectedValue)
            {
                case "Bicycle":
                case "Motorbike":
                case "Quad":
                    family = "Bike";
                    break;

                case "RaceCar":
                case "Truck":
                case "Jeep":
                    family = "Car";
                    break;
            }
            return family;
        }
        private async Task Connect(object sender, EventArgs e)
        {
            //Validacija
            if (UsernameTextBox.Text == "")
                return;
            if (VehiclesDropDown.SelectedValue == "")
                return;

            // Lauku isjungimas
            UsernameLabel.Enabled = false;
            UsernameTextBox.Enabled = false;
            VehicleLabel.Enabled = false;
            VehiclesDropDown.Enabled = false;
            ConnectButton.Enabled = false;

            //HttpResponseMessage response = await client.GetAsync($"game/connect/{UsernameTextBox.Text}/{family}/{VehiclesDropDown.SelectedValue}");
            //string json = await response.Content.ReadAsAsync<string>() + "\n";
            //OutputLog.Text += json;
            //_instance.Vehicles.Add(JsonConvert.DeserializeObject<Vehicle>(json));
            ChatHub.Start();
            ChatHub.Connect(UsernameTextBox.Text, getFamilyFromSelection(VehiclesDropDown.SelectedValue.ToString()), VehiclesDropDown.SelectedValue.ToString());

            StatusDescriptionLabel.Text = "Connected";
            message.ReadOnly = false;
            Connected = true;
        }

        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            await Connect(sender, e);
        }

        private void CosmosInvaders_Client_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Connected)
                return;
            if (message.Focused)
                return;
            char moveTo = ' ';
            bool turn = false;

            switch (e.KeyCode)
            {
                case Keys.W:
                    moveTo = 'w';
                    break;

                case Keys.A:
                    moveTo = 'a';
                    turn = true;
                    break;

                case Keys.S:
                    moveTo = 's';
                    break;

                case Keys.D:
                    moveTo = 'd';
                    turn = true;
                    break;

                default:
                    return;
            }

            //Vehicle clientVehicle = _instance.Vehicles.Find(x => x.PlayerName == UsernameTextBox.Text);
            //HttpResponseMessage response = await client.GetAsync($"game/move/{UsernameTextBox.Text}/{moveTo}");
            //string json = await response.Content.ReadAsAsync<string>() + "\n";
            //OutputLog.Text += "----------\n" + json;
            //Vehicle serverVehicle = JsonConvert.DeserializeObject<Vehicle>(json);

            //if (!turn)
            //{
            //    clientVehicle.Speed = serverVehicle.Speed;
            //    clientVehicle.CoordinateX = serverVehicle.CoordinateX;
            //    clientVehicle.CoordinateY = serverVehicle.CoordinateY;

            //    SpeedValue.Text = serverVehicle.Speed.ToString();

            //    GameDraw.DrawCar(clientVehicle.CoordinateX, clientVehicle.CoordinateY);
            //}
            //else
            //{
            //    clientVehicle.DrivingDirection = serverVehicle.DrivingDirection;
            //    DirectionValue.Text = serverVehicle.DrivingDirection.ToString();
            //    GameDraw.TurnCar(clientVehicle.DrivingDirection);
            //}

            ChatHub.Move(UsernameTextBox.Text, moveTo);
        }

        private void CosmosInvaders_Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Connected)
            {
                ChatHub.Disconnect();
                ChatHub.Stop();
            }
        }

        private void sendMessage_Click(object sender, EventArgs e)
        {
            string mes = message.Text;
            string userName = UsernameTextBox.Text;
            if (mes != "" && userName != "")
            {
                if(mes[0] == '/')
                {
                    ExecuteCommand(userName,mes );
                }
                else
                {
                    ChatHub.SendMessage(userName, mes);
                }
            }
            message.Text = "";
        }

        private void logBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void OutputLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChatHub.originator.getStateFromMemento(ChatHub.careTaker.getLast());

            ChatHub.MementoReposition(
                UsernameTextBox.Text, 
                ChatHub.originator.getState().CoordinateX, 
                ChatHub.originator.getState().CoordinateY
                );
        }

        private void positionSaves_TextChanged(object sender, EventArgs e)
        {

        }
        private void ExecuteCommand(string userName, string mes)
        {
            Parser.Parse(mes);
            Boolean debuging = true;
            if (debuging)
            {
                IIterator iterator = Parser.getIterator();
                while (iterator.HasNext())
                {
                    ChatHub.SendMessage(userName, iterator.ToString());
                    iterator = iterator.Next();
                }
                ChatHub.SendMessage(userName, iterator.ToString());
            }
            Parser.Execute();
        }
    }
}