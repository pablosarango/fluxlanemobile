using System;
namespace FlyCar.Models
{
    public class ItemResponse
    {
        public ItemResponse()
        {
        }

        private int status;

        public int STATUS
        {
            get { return status; }
            set { status = value; }
        }

        private string message;

        public string MESSAGE
        {
            get { return message; }
            set { message = value; }
        }

        private string id;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
    }
}
