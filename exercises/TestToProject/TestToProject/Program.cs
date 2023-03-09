
using System.Security.Cryptography.X509Certificates;

namespace TestToProject
{

    class Program
    {
        static void Main(string[] args)
        {
        }

    }
    
    public class Email
    {
        public string Sender;
        public string Receiver;
        public string Message;
        public bool Sent = false;
        public int Priority;

        public Email(string sender, string reciever, string message, int priority)
        {
            this.Sender = sender;
            this.Receiver = reciever;
            this.Message = message;
            this.Priority = priority;
        }

        public bool Send()
        {
            if(Sent == true)
            {
                return false;
            }
            Sent = true;
            return Sent;
        }
    }

    
    public class MailAccount
    {
        public static Dictionary<string, MailAccount> accounts = new Dictionary<string, MailAccount>();

        Email[] inboxEmails = new Email[10];
        public MailAccount()
        {
            inboxEmails[0] = new Email("sender", "receiver", "message", 5);
        }

        public Email[] GetInbox()
        {
            return inboxEmails;
        }
    }
}

