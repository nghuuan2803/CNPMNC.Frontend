using AdminUI.ApiServices;
using MudBlazor;

namespace AdminUI.Objects
{
    public class SuplierModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Discontinued { get; set; }
        public string ContactPerson { get; set; }

        public SuplierModel(int id, string name, string address, string email, string phonenumber, bool discontinued, string contactperson)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phonenumber;
            Discontinued = discontinued;
            ContactPerson = contactperson;
        }
        public SuplierModel()
        { }
        public SuplierModel(SuplierModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Address = model.Address;
            Email = model.Email;
            PhoneNumber = model.PhoneNumber;
            Discontinued = model.Discontinued;
        }
    }
    public class SuplierResponse
    {
        public string Message { get; set; }
        public SuplierModel Data{ get; set; }

    }
    public class ListSuplierModel
    {
        public string Message { get; set; }
        public List<SuplierModel> Data { get; set; }

    }
    
}
