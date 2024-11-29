using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzverwaltung
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }

        //public List<string> usernames = new List<string>();
        //public List<string> password = new List<string>();
        Dictionary<string, string>users = new Dictionary<string, string>();

        public Login() 
        {
            //usernames.Add("Dom");
            //password.Add("123456");
            users.Add("Dom","12345");
            users.Add("Dirk","54321");
            users.Add("Heike","678910");
        }
        
        public string login(string name, string passwort) 
        {
            string login = "";
            if(users.ContainsKey(name) && users[name] == passwort)
            {
                Console.WriteLine("Herzlich willkomen im Finanzverwaltungsprogramm");
                login = "Erfolgreich";
                return login;
            }
            else
            {
                Console.WriteLine("User Name ist Falsch oder Passwort. Bitte nochmal eingeben.");
                login = "Falsch";
                return login;
            }
        }
    }
}
