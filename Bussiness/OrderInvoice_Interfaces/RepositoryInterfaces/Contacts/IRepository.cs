// ***********************************************************************
// Assembly         : OrderInvoice_Interfaces
// Author           : Bill Barge
// Created          : 03-01-2023
//
// Last Modified By : Bill Barge
// Last Modified On : 03-01-2023
// ***********************************************************************
// <copyright file="IRepository.cs" company="OrderInvoice_Interfaces">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using OrderInvoice_Interfaces.DB_DTOs;

namespace OrderInvoice_Interfaces.RepositoryInterfaces
{
    /// <summary>
    /// Interface IRepository
    /// </summary>
    public partial interface IRepository
    {
        #region Phone Number Type
        /// <summary>
        /// Gets the type of the phone number.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IPhoneNumberType.</returns>
        IPhoneNumberType GetPhoneNumberType(int id);
        /// <summary>
        /// Gets the phone number types.
        /// </summary>
        /// <returns>IEnumerable&lt;IPhoneNumberType&gt;.</returns>
        IEnumerable<IPhoneNumberType> GetPhoneNumberTypes();
        /// <summary>
        /// Creates the type of the phone number.
        /// </summary>
        /// <returns>IPhoneNumberType.</returns>
        IPhoneNumberType CreatePhoneNumberType();
        /// <summary>
        /// Inserts the type of the phone number.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertPhoneNumberType(IPhoneNumberType newObj);
        /// <summary>
        /// Updates the type of the phone number.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdatePhoneNumberType(IPhoneNumberType obj);
        /// <summary>
        /// Deletes the type of the phone number.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeletePhoneNumberType(int id);
        #endregion Phone Number Type

        #region PhoneNumber Methods
        /// <summary>
        /// Gets the phone number.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IPhoneNumbers.</returns>
        IPhoneNumbers GetPhoneNumber(int id);
        /// <summary>
        /// Gets the phone numbers.
        /// </summary>
        /// <returns>IEnumerable&lt;IPhoneNumbers&gt;.</returns>
        IEnumerable<IPhoneNumbers> GetPhoneNumbers();
        /// <summary>
        /// Creates the phone number.
        /// </summary>
        /// <returns>IPhoneNumbers.</returns>
        IPhoneNumbers CreatePhoneNumber();
        /// <summary>
        /// Inserts the phone number.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertPhoneNumber(IPhoneNumbers newObj);
        /// <summary>
        /// Updates the phone number.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdatePhoneNumber(IPhoneNumbers obj);
        /// <summary>
        /// Deletes the phone number for all contacts.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeletePhoneNumber(int id);
        #endregion PhoneNumberType Methods

        #region Email Address Methods
        /// <summary>
        /// Gets the email address.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IEMailAddresses.</returns>
        IEMailAddresses GetEmailAddress(int id);
        /// <summary>
        /// Gets the email addresses.
        /// </summary>
        /// <returns>IEnumerable&lt;IEMailAddresses&gt;.</returns>
        IEnumerable<IEMailAddresses> GetEmailAddresses();
        /// <summary>
        /// Creates the email address.
        /// </summary>
        /// <returns>IEMailAddresses.</returns>
        IEMailAddresses CreateEmailAddress();
        /// <summary>
        /// Inserts the email address.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertEmailAddress(IEMailAddresses newObj);
        /// <summary>
        /// Updates the email address.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateEmailAddress(IEMailAddresses obj);
        /// <summary>
        /// Deletes the email address.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteEmailAddress(int id);
        #endregion Email Address Methods

        #region Snail Mail Type
        /// <summary>
        /// Gets the type of the snail mail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ISnailMailType.</returns>
        ISnailMailType GetSnailMailType(int id);
        /// <summary>
        /// Gets the snail mail types.
        /// </summary>
        /// <returns>IEnumerable&lt;ISnailMailType&gt;.</returns>
        IEnumerable<ISnailMailType> GetSnailMailTypes();
        /// <summary>
        /// Creates the type of the snail mail.
        /// </summary>
        /// <returns>ISnailMailType.</returns>
        ISnailMailType CreateSnailMailType();
        /// <summary>
        /// Inserts the type of the snail mail.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertSnailMailType(ISnailMailType newObj);
        /// <summary>
        /// Updates the type of the snail mail.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateSnailMailType(ISnailMailType obj);
        /// <summary>
        /// Deletes the type of the snail mail.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteSnailMailType(int id);
        #endregion Snail Mail Type

        #region State Methods

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IStates.</returns>
        IStates GetState(int id);
        /// <summary>
        /// Gets the states.
        /// </summary>
        /// <returns>IEnumerable&lt;IStates&gt;.</returns>
        IEnumerable<IStates> GetStates();
        /// <summary>
        /// Creates the state.
        /// </summary>
        /// <returns>IStates.</returns>
        IStates CreateState();
        /// <summary>
        /// Inserts the state.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertState(IStates newObj);
        /// <summary>
        /// Updates the state.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateState(IStates obj);
        /// <summary>
        /// Deletes the state.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteState(int id);

        #endregion State Methods

        #region Country Methods

        /// <summary>
        /// Gets the country.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ICountry.</returns>
        ICountry GetCountry(int id);
        /// <summary>
        /// Gets the countries.
        /// </summary>
        /// <returns>IEnumerable&lt;ICountry&gt;.</returns>
        IEnumerable<ICountry> GetCountries();
        /// <summary>
        /// Creates the country.
        /// </summary>
        /// <returns>ICountry.</returns>
        ICountry CreateCountry();
        /// <summary>
        /// Inserts the country.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertCountry(ICountry newObj);
        /// <summary>
        /// Updates the country.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateCountry(ICountry obj);
        /// <summary>
        /// Deletes the country.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteCountry(int id);

        #endregion Country Methods

        #region SnailMailAddress Methods

        /// <summary>
        /// Gets the snail mail address.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ISnailMailAddresses.</returns>
        ISnailMailAddresses GetSnailMailAddress(int id);
        /// <summary>
        /// Gets the snail mail addresses.
        /// </summary>
        /// <returns>IEnumerable&lt;ISnailMailAddresses&gt;.</returns>
        IEnumerable<ISnailMailAddresses> GetSnailMailAddresses();
        /// <summary>
        /// Creates the snail mail address.
        /// </summary>
        /// <returns>ISnailMailAddresses.</returns>
        ISnailMailAddresses CreateSnailMailAddress();
        /// <summary>
        /// Inserts the snail mail address.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertSnailMailAddress(ISnailMailAddresses newObj);
        /// <summary>
        /// Updates the snail mail address.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateSnailMailAddress(ISnailMailAddresses obj);
        /// <summary>
        /// Deletes the snail mail address.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteSnailMailAddress(int id);

        #endregion SnailMailAddress Methods

        #region Contact
        /// <summary>
        /// Gets the contact.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IContacts.</returns>
        IContacts GetContact(int id);
        /// <summary>
        /// Gets the contacts.
        /// </summary>
        /// <returns>IEnumerable&lt;IContacts&gt;.</returns>
        IEnumerable<IContacts> GetContacts();
        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <returns>IContacts.</returns>
        IContacts CreateContact();
        /// <summary>
        /// Inserts the contact.
        /// </summary>
        /// <param name="newObj">The new object.</param>
        void InsertContact(IContacts newObj);
        /// <summary>
        /// Updates the contact.
        /// </summary>
        /// <param name="obj">The object.</param>
        void UpdateContact(IContacts obj);
        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteContact(int id);
        /// <summary>
        /// Sets the default phone number.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="phoneNumberId">The phone number identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool SetDefaultPhoneNumber(int contactId, int phoneNumberId);
        /// <summary>
        /// Gets the default phone number.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>IPhoneNumbers.</returns>
        IPhoneNumbers GetDefaultPhoneNumber(int contactId);
        /// <summary>
        /// Gets the contact phone numbers.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns>IEnumerable&lt;IPhoneNumbers&gt;.</returns>
        IEnumerable<IPhoneNumbers> GetContactPhoneNumbers(int contactId, bool includeDeleted);
        /// <summary>
        /// Adds the phone number to contact.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="phoneNumberId">The phone number identifier.</param>
        void AddPhoneNumberToContact(int contactId, int phoneNumberId);
        /// <summary>
        /// Removes the phone number from contact.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="phoneNumberId">The phone number identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool RemovePhoneNumberFromContact(int contactId, int phoneNumberId);
        /// <summary>
        /// Sets the default snail mail address.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="snailMailAddesId">The snail mail address identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool SetDefaultSnailMailAddress(int contactId, int snailMailAddesId);
        /// <summary>
        /// Gets the default snail mail address.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <returns>ISnailMailAddresses.</returns>
        ISnailMailAddresses GetDefaultSnailMailAddress(int contactId);
        /// <summary>
        /// Gets the contact snail mail addresses.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="includeDeleted">if set to <see langword="true" /> [include deleted].</param>
        /// <returns>IEnumerable&lt;ISnailMailAddresses&gt;.</returns>
        IEnumerable<ISnailMailAddresses> GetContactSnailMailAddresses(int contactId, bool includeDeleted);
        /// <summary>
        /// Adds the snail mail address to contact.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="snailMailAddressId">The snail mail address identifier.</param>
        void AddSnailMailAddressToContact(int contactId, int snailMailAddressId);
        /// <summary>
        /// Removes the snail mail address from contact.
        /// </summary>
        /// <param name="contactId">The contact identifier.</param>
        /// <param name="snailMailAddressId">The snail mail address identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool RemoveSnailMailAddressFromContact(int contactId, int snailMailAddressId);
        #endregion Contact

    }
}
