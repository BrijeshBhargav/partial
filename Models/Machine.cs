using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace MVCWebAppHTD3.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name  { get; set; }
       
        public string Ph_no { get; set; }
        public string Idproof { get; set; }
      
        public string IdRoof_No { get; set; }
        public string Member_id { get; set; }
        public DateTime Joining_Date { get; set; }
        public string Names { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }

    }
    public class Machine2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Mobile can't be empty")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Ph_no { get; set; }
        public string Idproof { get; set; }

        public string IdRoof_No { get; set; }
        public string Member_id { get; set; }
        public DateTime Joining_Date { get; set; }
    }
    public class Machine3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public int salary { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobile can't be empty")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }
        public string Qualification { get; set; }

        public string Manager { get; set; }
    }

}
