using System;
using System.Linq;
using LuckySpin.Models;
using System.ComponentModel.DataAnnotations;

namespace LuckySpin.ViewModels
{
	public class IndexViewModel {
		[Required]
		public string PlayerNmae { get; set; }
		[Range(1, 9, ErrorMessage = "Please enter a number")]
		public string PlayerLuck { get; set; }
		[Range(1, 9, ErrorMessage = "Please enter a number between 3 and 10")]
		public decimal StartoutCash { get; set; }



	}