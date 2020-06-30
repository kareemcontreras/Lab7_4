using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace Lab7_4
{
    //Create Dating Profile
    class DatingProfile
    //Create Profile Properties
    {
        public string firstName;
        private string lastName;
        public int age;
        public string gender;
        public string bio;
        private List<Messages> myMessages;

        //Constructor
        public DatingProfile(string firstName, string lastName, int age, string gender)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.gender = gender;
            myMessages = new List<Messages>();
        }
        //Different Methods
        public void WriteBio(string text)
        {
            bio = text;
        }
        private void AddToInbox(Messages message)
        {
            myMessages.Add(message);
        }
            public void SendMessage(string messageTitle, string messageData, DatingProfile sentTo)
            {
                Messages message = new Messages(this, messageTitle, messageData);
                sentTo.AddToInbox(message);

            }
        public void ReadMessage()
        {
            foreach (Messages message in myMessages)
            {
                if (message.isRead == false)
                {
                    Console.WriteLine(message.messageTitle);
                    Console.WriteLine(message.messageData);
                    message.isRead = true;
                }
            }
        }

       class Messages
        {
            public DatingProfile sender;
            public string messageTitle;
            public string messageData;
            public bool isRead;

            public Messages(DatingProfile sender, string messageTitle, string messageData)
            {
                this.sender = sender;
                this.messageTitle = messageTitle;
                this.messageData = messageData;
                isRead = false;
            }
        }
        class Program
        {
            static void Main(string[] args)//Testing classes
            {
                DatingProfile sylvester = new DatingProfile("Sylvester", "Stallone", 45, "Male");
                sylvester.WriteBio("Adventurer and thrill seeker");

                DatingProfile sandra = new DatingProfile("Sandra", "Bullock", 40, "Female");
                sandra.WriteBio("Classy and romantic");

                sylvester.SendMessage("Hello Sandra", "Would You like to go on an exploration with me?", sandra);
                sandra.ReadMessage();
            }

        }

       
    }
}