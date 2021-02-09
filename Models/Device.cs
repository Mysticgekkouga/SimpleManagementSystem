using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SimpleManagementSystem.Models
{
    public class Device
    {
        [Key]
        [Required]
        public string SerialNumber { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [DefaultValue(0)]
        public int Stock { get; set; }
    }
}