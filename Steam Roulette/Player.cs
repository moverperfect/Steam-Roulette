using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Steam_Roulette
{
    class Player
    {
        public List<Game> ListOfGames { get; set; }

        public String ID64 { get; set; }

        public String Name { get; set; }

        public Player()
        {
            ListOfGames = new List<Game>();
        }

        public void ParseData(String url)
        {
            var reader = XmlReader.Create(url);


            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.Name)
                        {
                            case "game":
                                var temp = new Game();
                                reader.Read();
                                reader.Read();
                                reader.Read();
                                temp.AppId = Convert.ToInt32(reader.Value);
                                reader.Read();
                                reader.Read();
                                reader.Read();
                                reader.Read();
                                temp.Name = reader.Value;
                                ListOfGames.Add(temp);
                                break;

                            case "steamID64":
                                reader.Read();
                                ID64 = reader.Value;
                                break;

                            case "steamID":
                                reader.Read();
                                Name = reader.Value;
                                break;
                        }
                        break;

                    case XmlNodeType.EndElement:
                        if (reader.Name == "games")
                            return;
                        break;
                }
            }
        }
    }
}
