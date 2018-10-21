using Common.Application;

namespace EnterprisePatterns.Api.Customers
{
    public class Customer
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string IdentificationNumber { get; set; }

        public Customer()
        {
        }

        public virtual bool hasFullName()
        {
            return !string.IsNullOrWhiteSpace(this.Name);
        }

        public virtual bool hasIdentificationNumber()
        {
            return !string.IsNullOrWhiteSpace(this.IdentificationNumber);
        }

        public virtual Notification ValidateForSearch()
        {
            Notification notification = new Notification();

            if (this == null)
            {
                notification.addError("The customer is null");
            }

            if (!this.hasIdentificationNumber())
            {
                notification.addError("The customer doesn´t have a valid IdentificationNumber");
            }

            return notification;
        }

        public virtual Notification validateForSave()
        {
            Notification notification = new Notification();

            if (this == null)
            {
                notification.addError("The customer is null");
            }

            if (!this.hasFullName())
            {
                notification.addError("The customer doesn´t have a valid name");
            }

            return notification;
        }
    }
}
