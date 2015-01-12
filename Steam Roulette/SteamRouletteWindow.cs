using System;
using System.Windows.Forms;

namespace Steam_Roulette
{
    public partial class SteamRouletteWindow : Form
    {
        public SteamRouletteWindow()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.Player2 == null)
                {
                    var rnd = new Random();
                    var random = rnd.Next(0, Program.Player1.ListOfGames.Count - 1);

                    label2.Text = Program.Player1.ListOfGames[random].Name;
                }
                else
                {
                    var tempPlayer = new Player();
                    foreach (var game in Program.Player1.ListOfGames)
                    {
                        foreach (var game2 in Program.Player2.ListOfGames)
                        {
                            if (game.AppId == game2.AppId)
                            {
                                tempPlayer.ListOfGames.Add(game);
                            }
                        }
                    }
                    var rnd = new Random();
                    var random = rnd.Next(0, tempPlayer.ListOfGames.Count - 1);

                    label2.Text = tempPlayer.ListOfGames[random].Name;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 id64;
                string url;
                if (Int64.TryParse(textBox1.Text, out id64))
                {
                    url = "http://steamcommunity.com/profiles/" + id64 + "/games?xml=1";
                }
                else
                {
                    url = "http://steamcommunity.com/id/" + textBox1.Text + "/games?xml=1";
                }
                Program.Player1 = new Player();
                Program.Player1.ParseData(url);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            try
            {
                int id64;
                string url;
                if (textBox2.Text == "")
                    throw new Exception();
                if (int.TryParse(textBox2.Text, out id64))
                {
                    url = "http://steamcommunity.com/profiles/" + id64 + "/games?xml=1";
                }
                else
                {
                    url = "http://steamcommunity.com/id/" + textBox2.Text + "/games?xml=1";
                }
                Program.Player2 = new Player();
                Program.Player2.ParseData(url);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            MessageBox.Show("Loaded");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Player1 = null;
            Program.Player2 = null;
            label2.Text = "The Game";
        }
    }
}
