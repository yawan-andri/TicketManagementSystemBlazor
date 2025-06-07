using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	public class Attachment
	{
		public int AttachmentId { get; set; }
		public string FileName { get; set; }
		public string ServerFileName { get; set; }
		public int FileSize { get; set; }
		public DateTime CreatedDate { get; set; }
		public int? TicketId { get; set; }
		[ForeignKey(nameof(Ticket))]
		public Ticket Ticket { get; set; }
		public int DiscussionId { get; set; }
		[ForeignKey(nameof(Discussion))]
		public Discussion Discussion { get; set; }	
	}
}
