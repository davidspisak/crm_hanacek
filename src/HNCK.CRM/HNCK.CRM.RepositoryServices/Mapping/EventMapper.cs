using HNCK.CRM.Dto.Event;
using HNCK.CRM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCK.CRM.Repository.Mapping
{
	public static class EventMapper
	{
		public static IEnumerable<UserEvent> Map(IEnumerable<UserEventDto> userEventDtos)
		{
			var userEvents = new List<UserEvent>();

			foreach (var userEvent in userEventDtos)
			{
				userEvents.Add(Map(userEvent));
			}
			return userEvents;
		}


		public static UserEvent Map(UserEventDto userEventDto)
		{
			return new UserEvent()
			{
				Decsription = userEventDto.Decsription,
				DueDate = userEventDto.DueDate,
				IdSubject = userEventDto.IdSubject,
				IdUserEvent = userEventDto.IdUserEvent,
				Name = userEventDto.Name,
				NotificationDate = userEventDto.NotificationDate,
				TerminationDate = userEventDto.TerminationDate,
				DeletedDate = userEventDto.DeletedDate
			};
		}
	}
}
