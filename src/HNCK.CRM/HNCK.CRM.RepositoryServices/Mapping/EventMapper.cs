using HNCK.CRM.Dto.Event;
using HNCK.CRM.Dto.Subject;
using HNCK.CRM.Model;
using HNCK.CRM.QueryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNCK.CRM.Repository.Mapping
{
	public static class EventMapper
	{
		public static IEnumerable<UserEventDto> Map(IEnumerable<UserEvents> userEvents)
		{
			var userEventDtos = new List<UserEventDto>();

			foreach (var userEvent in userEvents)
			{
				userEventDtos.Add(Map(userEvent));
			}
			return userEventDtos;
		}


		public static UserEventDto Map(UserEvents userEventDto)
		{
			return new UserEventDto()
			{
				Decsription = userEventDto.Decsription,
				DueDate = userEventDto.DueDate,
				IdSubject = userEventDto.IdSubject,
				IdUserEvent = userEventDto.IdUserEvent,
				Name = userEventDto.Name,
				NotificationDate = userEventDto.NotificationDate,
				TerminationDate = userEventDto.TerminationDate,
				DeletedDate = userEventDto.DeletedDate,
				Subject = new SubjectDto()
				{
					IdSubject = userEventDto.IdSubject,
					BirthDate = userEventDto.BirthDate,
					BusinessIdentificationNumber = userEventDto.BusinessIdentificationNumber,
					Email = userEventDto.Email,
					FirstName = userEventDto.FirstName,
					LastName = userEventDto.LastName,
					Note = userEventDto.LastName,
					PersonalIdentificationNumber = userEventDto.PersonalIdentificationNumber,
					ResidenceCardValidTo = userEventDto.ResidenceCardValidTo,
					TelNumber = userEventDto.TelNumber
				}
			};
		}


		public static IEnumerable<UserEvent> Map(IEnumerable<UserEventDto> userEventDtos)
		{
			var userEvents = new List<UserEvent>();

			if(userEventDtos != null)
			{
				foreach (var userEvent in userEventDtos)
				{
					userEvents.Add(Map(userEvent));
				}
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
