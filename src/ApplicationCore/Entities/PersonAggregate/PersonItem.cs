using Ardalis.GuardClauses;
using Metcom.CardPay3.ApplicationCore.Entities.AddressAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metcom.CardPay3.ApplicationCore.Entities.PersonAggregate
{
    public class PersonItem : BaseEntity
    {

        public PersonItem(
            int idPerson,
            string lastName,
            string firstName,
            string middleName,
            string latinFirstName,
            string latinLastName,
            int genderId,
            int documentId)
        {
            Id = idPerson;
            LastName = lastName;
            FirstName = firstName;
            middleName = MiddleName;

            LatinFirstName = latinFirstName;
            LatinLastName = latinLastName;

            IdGender = genderId;
            IdDocument = documentId;
        }

        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }

        /// <summary>
        /// Имя в латинице
        /// </summary>
        public string LatinFirstName { get; private set; }
        /// <summary>
        /// Фамилия в латинице
        /// </summary>
        public string LatinLastName { get; private set; }

        public int IdGender { get; private set; }
        public PersonGender Gender { get; private set; }
        public int IdDocument { get; set; }
        public PersonDocument Document { get; set; }
        public int IdAddress { get; set; }
        public Address Address { get; set; }

        public void UpdateFullName(string lastName, string firstName, string middleName)
        {
            Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            Guard.Against.NullOrEmpty(middleName, nameof(middleName));

            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
        }


        public void UpdateNameCard(string lastName, string firstName)
        {
            Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            
            LatinLastName = lastName;
            LatinFirstName = firstName;
        }
    }
}
