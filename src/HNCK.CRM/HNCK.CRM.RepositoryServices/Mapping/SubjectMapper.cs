using HNCK.CRM.Common;
using HNCK.CRM.Dto;
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
	public static class SubjectMapper
	{

		public static IEnumerable<SubjectDto> Map(IEnumerable<Subjects> subjects)
		{
			var subjectDtos = new List<SubjectDto>();

			foreach (var sub in subjects)
			{
				subjectDtos.Add(Map(sub));
			}

			return subjectDtos;
		}

		public static SubjectDto Map(Subjects subject)
		{
			var subjectDto = new SubjectDto()
			{
				BirthDate = subject.BirthDate,
				BusinessIdentificationNumber = subject.BusinessIdentificationNumber,
				Email = subject.Email,
				FirstName = subject.FirstName,
				IdSubject = subject.IdSubject,
				LastName = subject.LastName,
				Note = subject.Note,
				PersonalIdentificationNumber = subject.PersonalIdentificationNumber,
				ResidenceCardValidTo = subject.ResidenceCardValidTo,
				TelNumber = subject.TelNumber
			};

			return subjectDto;
		}


		public static SubjectDto Map(Subjects subject, Addresses addr)
		{
			var subjectDto = new SubjectDto()
			{
				BirthDate = subject.BirthDate,
				BusinessIdentificationNumber = subject.BusinessIdentificationNumber,
				Email = subject.Email,
				FirstName = subject.FirstName,
				IdSubject = subject.IdSubject,
				LastName = subject.LastName,
				Note = subject.Note,
				PersonalIdentificationNumber = subject.PersonalIdentificationNumber,
				ResidenceCardValidTo = subject.ResidenceCardValidTo,
				TelNumber = subject.TelNumber,
				Address = addr != null
					? new AddressDto()
					{
						CityName = addr.CityName,
						IdAddress = addr.IdAddress,
						IdAddressType = (int)Enums.AddressTypeEnum.PermanentResidence,
						IdCountry = addr?.IdCountry,
						StreetName = addr.StreetName,
						StreetNumber = addr.StreetNumber,
						ValidTo = addr.ValidTo,
						Zip = addr.Zip,
						CountryNameENShort = addr.CountryNameENShort
					}
					: null
			};

			return subjectDto;
		}

		public static Subject Map(SubjectDto subjectDto)
		{
			var addresses = new List<Address>();

			var subject = new Subject()
			{
				BirthDate = subjectDto.BirthDate,
				BusinessIdentificationNumber = subjectDto.BusinessIdentificationNumber,
				Email = subjectDto.Email,
				FirstName = subjectDto.FirstName,
				IdSubject = subjectDto.IdSubject,
				LastName = subjectDto.LastName,
				Note = subjectDto.Note,
				PersonalIdentificationNumber = subjectDto.PersonalIdentificationNumber,
				ResidenceCardValidTo = subjectDto.ResidenceCardValidTo,
				TelNumber = subjectDto.TelNumber,
				Addresses = addresses
			};

			addresses.Add(new Address()
			{
				CityName = subjectDto.Address.CityName,
				IdAddress = subjectDto.Address.IdAddress,
				IdAddressType = (int)Enums.AddressTypeEnum.PermanentResidence,
				IdCountry = subjectDto.Address.IdCountry,
				StreetName = subjectDto.Address.StreetName,
				StreetNumber = subjectDto.Address.StreetNumber,
				ValidTo = subjectDto.Address.ValidTo,
				Zip = subjectDto.Address.Zip,
				IdSubjectNavigation = subject
			});

			return subject;
		}



		public static IEnumerable<Attachment> Map(IEnumerable<AttachmentDto> attachmentDtos)
		{
			var attachments = new List<Attachment>();

			foreach (var att in attachmentDtos)
			{
				attachments.Add(Map(att));
			}

			return attachments;
		}

		public static Attachment Map(AttachmentDto attachmentDto)
		{
			var attachment = new Attachment()
			{
				ContentType = attachmentDto.ContentType,
				DeletedAt = attachmentDto.DeletedAt,
				Extension = attachmentDto.Extension,
				IdAttachment = attachmentDto.IdAttachment,
				IdSubject = attachmentDto.IdSubject,
				Name = attachmentDto.Name,
				RelativePath = attachmentDto.RelativePath,
				Size = attachmentDto.Size
			};

			return attachment;
		}

		public static IEnumerable<AttachmentDto> Map(IEnumerable<Attachments> attachments)
		{
			var attachmentDtos = new List<AttachmentDto>();

			foreach (var att in attachments)
			{
				attachmentDtos.Add(Map(att));
			}

			return attachmentDtos;
		}

		public static AttachmentDto Map(Attachments attachment)
		{
			var attachmentDto = new AttachmentDto()
			{
				ContentType = attachment.ContentType,
				DeletedAt = attachment.DeletedAt,
				Extension = attachment.Extension,
				IdAttachment = attachment.IdAttachment,
				IdSubject = (int)attachment.IdSubject,
				Name = attachment.Name,
				RelativePath = attachment.RelativePath,
				Size = attachment.Size
			};

			return attachmentDto;
		}
	}
}
