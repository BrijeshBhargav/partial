namespace MVCWebAppHTD3.Models
{
    public class AddressModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
    public class FamilyModel
    {
        public string DoorNo { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }

    }
    public class FamilyAddModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }

    }
    public class EmpModel
    {

      
        public string Name { get; set; }
       
        public string City { get; set; }
   
        public string Address { get; set; }
    }
}
