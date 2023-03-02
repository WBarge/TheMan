// ***********************************************************************
// Assembly         : OrderInvoice_DL
// Author           : Bill Barge
// Created          : 01-14-2017
//
// Last Modified By : Admin
// Last Modified On : 01-24-2017
// ***********************************************************************
// <copyright file="Repository.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;
using Utilites;
using OrderInvoice_Interfaces.RepositoryInterfaces;
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_DL.Repository
{
    /// <summary>
    /// This part of the class will hold all methods needed by the contacts area of the system
    /// </summary>
    /// <seealso cref="IRepository" />
    public partial class Repository : IRepository
	{
        #region PhoneNumberType Methods

        /// <summary>
        /// Gets the type of the phone number.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IPhoneNumberType.</returns>
        public IPhoneNumberType GetPhoneNumberType(int id)
		{
            return Context.PhoneNumberType.Get(id);
		}

        /// <summary>
        /// Gets the phone number types.
        /// </summary>
        /// <returns>IEnumerable&lt;IPhoneNumberType&gt;.</returns>
        public IEnumerable<IPhoneNumberType> GetPhoneNumberTypes()
		{
            return Enumerable.ToList<IPhoneNumberType>(Context.PhoneNumberType.GetAll());
		}

        /// <summary>
        /// Creates the type of the phone number.
        /// </summary>
        /// <returns>IPhoneNumberType.</returns>
        public IPhoneNumberType CreatePhoneNumberType()
		{
			return Context.PhoneNumberType.Create();
		}

        /// <summary>
        /// Inserts the type of the phone number.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertPhoneNumberType(IPhoneNumberType newObj)
		{
			Context.PhoneNumberType.Insert(newObj);
		}

        /// <summary>
        /// Updates the type of the phone number.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdatePhoneNumberType(IPhoneNumberType obj)
		{
            Context.PhoneNumberType.Update(obj);
        }

        /// <summary>
        /// Deletes the type of the phone number.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeletePhoneNumberType(int id)
		{
            Context.PhoneNumberType.Delete(GetPhoneNumberType(id));
		}

        #endregion PhoneNumberType Methods

        #region PhoneNumber Methods

        /// <summary>
        /// Gets the phone number.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IPhoneNumbers.</returns>
        public IPhoneNumbers GetPhoneNumber(int id)
		{
            return Context.PhoneNumbers.Get(id);
		}

        /// <summary>
        /// Gets the phone numbers.
        /// </summary>
        /// <returns>IEnumerable&lt;IPhoneNumbers&gt;.</returns>
        public IEnumerable<IPhoneNumbers> GetPhoneNumbers()
		{
            return Enumerable.ToList<IPhoneNumbers>(Context.PhoneNumbers.GetAll());
        }

        /// <summary>
        /// Creates the phone number.
        /// </summary>
        /// <returns>IPhoneNumbers.</returns>
        public IPhoneNumbers CreatePhoneNumber()
		{
			return Context.PhoneNumbers.Create();
		}

        /// <summary>
        /// Inserts the phone number.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertPhoneNumber(IPhoneNumbers newObj)
		{
            Context.PhoneNumbers.Insert(newObj);
        }

        /// <summary>
        /// Updates the phone number.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdatePhoneNumber(IPhoneNumbers obj)
		{
            Context.PhoneNumbers.Update(obj);
        }

        /// <summary>
        /// Deletes the phone number for all contacts.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeletePhoneNumber(int id)
		{
            List<IMtmPhone> connnections = Queryable.Where<IMtmPhone>(Context.MtmPhone.GetAll(), mp => mp.PhoneNumberObjid == id).ToList();
            foreach (IMtmPhone connection in connnections)
            {
                Context.MtmPhone.Delete(connection);
            }
            Context.PhoneNumbers.Delete(GetPhoneNumber(id));
		}

        #endregion PhoneNumber Methods

        #region Email Address Methods
        /// <summary>
        /// Gets the email address.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IEMailAddresses.</returns>
        public IEMailAddresses GetEmailAddress(int id)
		{
            return Context.EMailAddresses.Get(id);
		}

        /// <summary>
        /// Gets the email addresses.
        /// </summary>
        /// <returns>IEnumerable&lt;IEMailAddresses&gt;.</returns>
        public IEnumerable<IEMailAddresses> GetEmailAddresses()
		{
            return Enumerable.ToList<IEMailAddresses>(Context.EMailAddresses.GetAll());
		}

        /// <summary>
        /// Creates the email address.
        /// </summary>
        /// <returns>IEMailAddresses.</returns>
        public IEMailAddresses CreateEmailAddress()
		{
			return Context.EMailAddresses.Create();
		}

        /// <summary>
        /// Inserts the email address.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertEmailAddress(IEMailAddresses newObj)
		{
            Context.EMailAddresses.Insert(newObj);
		}

        /// <summary>
        /// Updates the email address.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateEmailAddress(IEMailAddresses obj)
		{
            Context.EMailAddresses.Update(obj);
		}

        /// <summary>
        /// Deletes the email address.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteEmailAddress(int id)
		{
            Context.EMailAddresses.Delete(GetEmailAddress(id));
		}
        #endregion Email Address Methods

        #region SnailMailType Methods

        /// <summary>
        /// Gets the type of the snail mail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ISnailMailType.</returns>
        public ISnailMailType GetSnailMailType(int id)
		{
            return Context.SnailMailType.Get(id);
		}

        /// <summary>
        /// Gets the snail mail types.
        /// </summary>
        /// <returns>IEnumerable&lt;ISnailMailType&gt;.</returns>
        public IEnumerable<ISnailMailType> GetSnailMailTypes()
		{
            return Enumerable.ToList<ISnailMailType>(Context.SnailMailType.GetAll());
		}

        /// <summary>
        /// Creates the type of the snail mail.
        /// </summary>
        /// <returns>ISnailMailType.</returns>
        public ISnailMailType CreateSnailMailType()
		{
			return Context.SnailMailType.Create();
		}

        /// <summary>
        /// Inserts the type of the snail mail.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertSnailMailType(ISnailMailType newObj)
		{
            Context.SnailMailType.Insert(newObj);
		}

        /// <summary>
        /// Updates the type of the snail mail.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateSnailMailType(ISnailMailType obj)
		{
            Context.SnailMailType.Update(obj);
		}

        /// <summary>
        /// Deletes the type of the snail mail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteSnailMailType(int id)
		{
            Context.SnailMailType.Delete(GetSnailMailType(id));
		}

        #endregion SnailMailType Methods

        #region State Methods

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IStates.</returns>
        public IStates GetState(int id)
		{
            return Context.States.Get(id);
		}

        /// <summary>
        /// Gets the states.
        /// </summary>
        /// <returns>IEnumerable&lt;IStates&gt;.</returns>
        public IEnumerable<IStates> GetStates()
		{
            return Enumerable.ToList<IStates>(Context.States.GetAll());
        }

        /// <summary>
        /// Creates the state.
        /// </summary>
        /// <returns>IStates.</returns>
        public IStates CreateState()
		{
			return Context.States.Create();
		}

        /// <summary>
        /// Inserts the state.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertState(IStates newObj)
		{
            Context.States.Insert(newObj);
        }

        /// <summary>
        /// Updates the state.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateState(IStates obj)
		{
			Context.States.Update(obj);
		}

        /// <summary>
        /// Deletes the state.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteState(int id)
		{
            Context.States.Delete(GetState(id));
		}

        #endregion State Methods

        #region Country Methods

        /// <summary>
        /// Gets the country.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ICountry.</returns>
        public ICountry GetCountry(int id)
		{
            return Context.Country.Get(id);
		}

        /// <summary>
        /// Gets the countries.
        /// </summary>
        /// <returns>IEnumerable&lt;ICountry&gt;.</returns>
        public IEnumerable<ICountry> GetCountries()
		{
            return Enumerable.ToList<ICountry>(Context.Country.GetAll());
        }

        /// <summary>
        /// Creates the country.
        /// </summary>
        /// <returns>ICountry.</returns>
        public ICountry CreateCountry()
		{
			return Context.Country.Create();
		}

        /// <summary>
        /// Inserts the country.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertCountry(ICountry newObj)
		{
            Context.Country.Insert(newObj);
        }

        /// <summary>
        /// Updates the country.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateCountry(ICountry obj)
		{
            Context.Country.Update(obj);
		}

        /// <summary>
        /// Deletes the country.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteCountry(int id)
		{
			Context.Country.Delete(GetCountry(id));
		}

        #endregion Country Methods

        #region SnailMailAddress Methods

        /// <summary>
        /// Gets the snail mail address.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ISnailMailAddresses.</returns>
        public ISnailMailAddresses GetSnailMailAddress(int id)
		{
			return Context.SnailMailAddresses.Get(id);
		}

        /// <summary>
        /// Gets the snail mail addresses.
        /// </summary>
        /// <returns>IEnumerable&lt;ISnailMailAddresses&gt;.</returns>
        public IEnumerable<ISnailMailAddresses> GetSnailMailAddresses()
		{
            return Enumerable.ToList<ISnailMailAddresses>(Context.SnailMailAddresses.GetAll());
        }

        /// <summary>
        /// Creates the snail mail address.
        /// </summary>
        /// <returns>ISnailMailAddresses.</returns>
        public ISnailMailAddresses CreateSnailMailAddress()
		{
			return Context.SnailMailAddresses.Create();
		}

        /// <summary>
        /// Inserts the snail mail address.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertSnailMailAddress(ISnailMailAddresses newObj)
		{
			Context.SnailMailAddresses.Insert(newObj);
		}

        /// <summary>
        /// Updates the snail mail address.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateSnailMailAddress(ISnailMailAddresses obj)
		{
            Context.SnailMailAddresses.Update(obj);
		}

        /// <summary>
        /// Deletes the snail mail address.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteSnailMailAddress(int id)
		{
            Context.SnailMailAddresses.Delete(GetSnailMailAddress(id));
		}

        #endregion SnailMailAddress Methods

        #region Contact Methods

        /// <summary>
        /// Gets the contact.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IContacts.</returns>
        public IContacts GetContact(int id)
		{
            return Context.Contacts.Get(id);
		}

        /// <summary>
        /// Gets the contacts.
        /// </summary>
        /// <returns>IEnumerable&lt;IContacts&gt;.</returns>
        public IEnumerable<IContacts> GetContacts()
		{
            return Enumerable.ToList<IContacts>(Context.Contacts.GetAll());
		}

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <returns>IContacts.</returns>
        public IContacts CreateContact()
		{
			return Context.Contacts.Create();
		}

        /// <summary>
        /// Inserts the contact.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        public void InsertContact(IContacts newObj)
		{
			Context.Contacts.Insert(newObj);
		}

        /// <summary>
        /// Updates the contact.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void UpdateContact(IContacts obj)
		{
			Context.Contacts.Update(obj);
		}

        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteContact(int id)
		{
            Context.Contacts.Delete(GetContact(id));
		}

        /// <summary>
        /// Sets the default phone number.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="phoneNumberId">The phone number identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SetDefaultPhoneNumber(int contactId, int phoneNumberId)
		{
			bool returnValue = false;
			var connectingTable = Queryable.Where<IMtmPhone>(Context.MtmPhone.GetAll(), m => m.ContactObjid == contactId && m.PhoneNumberObjid == phoneNumberId).FirstOrDefault();
			if (connectingTable.IsNotEmpty())
			{
				returnValue = true;
                connectingTable.DefaultNumber = true;
                Context.MtmPhone.Update(connectingTable);
			}
			return returnValue;
		}

        /// <summary>
        /// Gets the default phone number.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>IPhoneNumbers.</returns>
        public IPhoneNumbers GetDefaultPhoneNumber(int contactId)
		{
            IPhoneNumbers returnValue = null;
			var connectionTableRecord = Queryable.Where<IMtmPhone>(Context.MtmPhone.GetAll(), m => m.ContactObjid == contactId && m.DefaultNumber != false).FirstOrDefault();
			if (connectionTableRecord.IsNotEmpty())
			{
				returnValue = GetPhoneNumber(connectionTableRecord.PhoneNumberObjid);
			}
			return returnValue;
		}

        /// <summary>
        /// Gets the contact phone numbers.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns>IEnumerable&lt;IPhoneNumbers&gt;.</returns>
        public IEnumerable<IPhoneNumbers> GetContactPhoneNumbers(int contactId, bool includeDeleted)
		{
			List<IPhoneNumbers> returnValue = new List<IPhoneNumbers>();
			var connectingTable = Queryable.Where<IMtmPhone>(Context.MtmPhone.GetAll(), c=>c.ContactObjid == contactId).ToList();
			if (connectingTable.IsNotEmpty())
			{
				foreach (IMtmPhone obj in connectingTable)
				{
                    var ph = GetPhoneNumber(obj.PhoneNumberObjid);
					if (includeDeleted)
					{
						returnValue.Add(ph);
					}
					else if (ph.Deleted == false)
					{
						returnValue.Add(ph);
					}
				}
			}
			return returnValue;
		}

        /// <summary>
        /// Adds the phone number to contact.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="phoneNumberId">The phone number identifier.</param>
        public void AddPhoneNumberToContact(int contactId, int phoneNumberId)
		{
            IMtmPhone connectionTable = Context.MtmPhone.Create();
			connectionTable.ContactObjid = contactId;
			connectionTable.PhoneNumberObjid = phoneNumberId;
			Context.MtmPhone.Insert(connectionTable);
		}

        /// <summary>
        /// Removes the phone number from contact.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="phoneNumberId">The phone number identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RemovePhoneNumberFromContact(int contactId, int phoneNumberId)
		{
			bool returnValue = false;
			IMtmPhone connectionTable = Queryable.Where<IMtmPhone>(Context.MtmPhone.GetAll(), mp => mp.PhoneNumberObjid == phoneNumberId && mp.ContactObjid == contactId).FirstOrDefault();
			if (connectionTable.IsNotEmpty())
			{
				Context.MtmPhone.Delete(connectionTable);
				returnValue = true;
			}
			return returnValue;
		}

        /// <summary>
        /// Sets the default snail mail address.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="snailMailAddesId">The snail mail addes identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SetDefaultSnailMailAddress(int contactId, int snailMailAddesId)
		{
			bool returnValue = false;
			IMtmSnailMail connectingTable = Queryable.Where<IMtmSnailMail>(Context.MtmSnailMail.GetAll(), m => m.ContactObjid == contactId && m.SnailMailAddessObjid == snailMailAddesId).FirstOrDefault();
			if (connectingTable.IsNotEmpty())
			{
				returnValue = true;
				connectingTable.DefaultAddress = true;
                Context.MtmSnailMail.Update(connectingTable);
			}
			return returnValue;
		}

        /// <summary>
        /// Gets the default snail mail address.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>ISnailMailAddresses.</returns>
        public ISnailMailAddresses GetDefaultSnailMailAddress(int contactId)
		{
			ISnailMailAddresses returnValue = null;
			IMtmSnailMail connectionTableRecord = Queryable.Where<IMtmSnailMail>(Context.MtmSnailMail.GetAll(), m => m.ContactObjid == contactId && m.DefaultAddress == true).FirstOrDefault();
			if (connectionTableRecord.IsNotEmpty())
			{
				returnValue = GetSnailMailAddress(connectionTableRecord.SnailMailAddessObjid);
			}
			return returnValue;
		}

        /// <summary>
        /// Gets the contact snail mail addresses.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns>IEnumerable&lt;ISnailMailAddresses&gt;.</returns>
        public IEnumerable<ISnailMailAddresses> GetContactSnailMailAddresses(int contactId, bool includeDeleted)
		{
			List<ISnailMailAddresses> returnValue = new List<ISnailMailAddresses>();
            List<IMtmSnailMail> connectingTable = Queryable.Where<IMtmSnailMail>(Context.MtmSnailMail.GetAll(), m => m.ContactObjid == contactId).ToList();

			if (connectingTable.IsNotEmpty())
			{
				foreach (IMtmSnailMail obj in connectingTable)
				{
                    ISnailMailAddresses address = GetSnailMailAddress(obj.SnailMailAddessObjid);
                    if (includeDeleted)
					{
                        returnValue.Add(address);
					}
					else if (address.Deleted == false)
					{
						returnValue.Add(address);
					}
				}
			}
			return returnValue;
		}

        /// <summary>
        /// Adds the snail mail address to contact.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="snailMailAddressId">The snail mail address identifier.</param>
        public void AddSnailMailAddressToContact(int contactId, int snailMailAddressId)
		{
            IMtmSnailMail connectionTable = Context.MtmSnailMail.Create();
			connectionTable.ContactObjid = contactId;
			connectionTable.SnailMailAddessObjid = snailMailAddressId;
			Context.MtmSnailMail.Insert(connectionTable);
		}

        /// <summary>
        /// Removes the snail mail address from contact.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="snailMailAddressId">The snail mail address identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RemoveSnailMailAddressFromContact(int contactId, int snailMailAddressId)
		{
			bool returnValue = false;
			IMtmSnailMail connectionTable = Queryable.Where<IMtmSnailMail>(Context.MtmSnailMail.GetAll(), ma => ma.SnailMailAddessObjid == snailMailAddressId && ma.ContactObjid == contactId).FirstOrDefault();
			if (connectionTable.IsNotEmpty())
			{
				Context.MtmSnailMail.Delete(connectionTable);
				returnValue = true;
			}
			return returnValue;
		}

		#endregion Contact Methods

		//#region Private helper Methods

		///// <summary>
		///// Searchs the DB for the passed in phone number type
		///// if none is found then a new phone number type record is created
		///// The type is then updated in the phone number
		///// </summary>
		///// <param name="phoneNumber">the phone number whose type need to be set</param>
		///// <param name="phoneNumberTypeStr">the phone number type as a string</param>
		//private void SearchAndFindRelatedObject(PhoneNumber phoneNumber, string phoneNumberTypeStr)
		//{
		//	PhoneNumberType idfPnt = context.PhoneNumberTypes.Where(p => p.type.Equals(phoneNumberTypeStr)).FirstOrDefault();
		//	if (idfPnt.IsNotEmpty())
		//	{
		//		phoneNumber.numberTypeObjid = idfPnt.objid;
		//	}
		//	else
		//	{
		//		IPhoneNumberTypeDTO newType = CreatePhoneNumberType();
		//		newType.Id = Guid.NewGuid();
		//		newType.Type = phoneNumber.InternalPhoneType;
		//		InsertPhoneNumberType(newType);
		//		phoneNumber.numberTypeObjid = newType.Id;
		//	}
		//}

		///// <summary>
		///// Searches the and find related object.
		///// </summary>
		///// <param name="address">The address.</param>
		///// <param name="mailType">Type of the mail.</param>
		//private void SearchAndFindRelatedObject(SnailMailAddress address, MailType mailType)
		//{
		//	string mailTypeStr = mailType.ToString();
		//	SnailMailType idfPnt = context.SnailMailTypes.Where(p => p.addressType.Equals(mailTypeStr)).FirstOrDefault();
		//	if (idfPnt.IsNotEmpty())
		//	{
		//		address.snailMailTypeObjid = idfPnt.objid;
		//	}
		//	else
		//	{
		//		ISnailMailTypeDTO newType = CreateSnailMailType();
		//		newType.Id = Guid.NewGuid();
		//		newType.AddressTypeAsString = address.InternalMailType.ToString();
		//		InsertSnailMailType(newType);
		//		address.snailMailTypeObjid = newType.Id;
		//	}
		//}

		///// <summary>
		///// Searches the and find related object.
		///// </summary>
		///// <param name="address">The address.</param>
		///// <param name="nonUS_StateNameStr">The non u s_ state n ame string.</param>
		//private void SearchAndFindRelatedObject(SnailMailAddress address, string nonUSStateNameStr)
		//{
		//	State idfPnt = context.States.Where(p => p.name.Equals(nonUSStateNameStr)).FirstOrDefault();
		//	if (idfPnt.IsNotEmpty())
		//	{
		//		address.stateObjId = idfPnt.objid;
		//	}
		//	else
		//	{
		//		IStateDTO newType = CreateState();
		//		newType.Id = Guid.NewGuid();
		//		newType.NameAsString = address.InternalNonUS_StateName;
		//		InsertState(newType);
		//		address.stateObjId = newType.Id;
		//	}
		//}

		///// <summary>
		///// Searches the and find related object.
		///// </summary>
		///// <param name="address">The address.</param>
		///// <param name="stateAbbr">The state abbr.</param>
		///// <param name="stateName">Name of the state.</param>
		//private void SearchAndFindRelatedObject(SnailMailAddress address, US_State_Abbreviation stateAbbr,US_State_Name stateName)
		//{
		//	string stName = stateName.ToString();
		//	string stAbbr = stateAbbr.ToString();
		//	State idfPnt = context.States.Where(p => p.name.Equals(stName) || p.abrv.Equals(stAbbr)).FirstOrDefault();
		//	if (idfPnt.IsNotEmpty())
		//	{
		//		address.stateObjId = idfPnt.objid;
		//	}
		//	else
		//	{
		//		IStateDTO newType = CreateState();
		//		newType.Id = Guid.NewGuid();
		//		newType.NameAsString = address.InternalStateName.ToString();
		//		newType.AbbreviationAsString = address.InternalStateAbbreviation.ToString();
		//		InsertState(newType);
		//		address.stateObjId = newType.Id;
		//	}
		//}

		///// <summary>
		///// Searches the and find related object.
		///// </summary>
		///// <param name="address">The address.</param>
		///// <param name="countryAbbr">The country abbr.</param>
		///// <param name="countryName">Name of the country.</param>
		//private void SearchAndFindRelatedObject(SnailMailAddress address, Country_Abbreviation countryAbbr, Country_Name countryName)
		//{
		//	string cName = countryName.ToString();
		//	string cAbbr = countryAbbr.ToString();
		//	Country idfPnt = context.Countries.Where(p => p.name.Equals(cName) || p.abrv.Equals(cAbbr)).FirstOrDefault();
		//	if (idfPnt.IsNotEmpty())
		//	{
		//		address.countryObjid = idfPnt.objid;
		//	}
		//	else
		//	{
		//		ICountryDTO newType = CreateCountry();
		//		newType.Id = Guid.NewGuid();
		//		newType.NameAsString = address.InternalCountryName.ToString();
		//		newType.AbbreviationAsString = address.InternalCountryAbbreviation.ToString();
		//		InsertCountry(newType);
		//		address.countryObjid = newType.Id;
		//	}
		//}


		//#endregion Private helper Methods
	}
}
