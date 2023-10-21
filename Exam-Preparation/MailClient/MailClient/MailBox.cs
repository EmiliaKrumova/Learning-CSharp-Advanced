using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public int Capacity  { get; set; }
        public List<Mail> Inbox  { get; set; }
        public List<Mail> Archive  { get; set; }

        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }
        //•	Method IncomingMail(Mail mail) – adds an entry to the Inbox collection, if the Capacity allows it.
        public void IncomingMail(Mail mail)
        {
            if (Capacity > Inbox.Count)
            {
                Inbox.Add(mail);
            }
        }
        //•	Method DeleteMail(string sender) – Finds and removes the first mail from the Inbox by a given 

        public bool DeleteMail(string sender)
        {
            Mail mailToDelete = Inbox.FirstOrDefault(x => x.Sender == sender);
            if (mailToDelete != null)
            {
                Inbox.Remove(mailToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int ArchiveInboxMessages()
        {
            int count = Inbox.Count;
            foreach (Mail mail in Inbox)
            {                
                Archive.Add(mail);             
               
            }
            Inbox.Clear();
            return count;
        }
        public string GetLongestMessage()
        {
            Mail mailLongest = Inbox.OrderByDescending(x=>x.Body.Length).First();
            return mailLongest.ToString().Trim();
        }

        public string InboxView()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inbox:");
            foreach (Mail mail in Inbox)
            {
                sb.AppendLine(mail.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
