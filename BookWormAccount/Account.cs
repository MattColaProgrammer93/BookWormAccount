using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWormAccount
{
    /// <summary>
    /// Represents a individual user's account
    /// </summary>
    public class Account
    {
        private string userName;

        /// <summary>
        /// Creates an account with the specific user, and has hours and books of 0
        /// </summary>
        /// <param name="userName">The user's name who owns the account</param>
        public Account(string userName)
        {
            UserName = userName;
        }
        /// <summary>
        /// The user's name of the account.
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set
            {
                // Check if value is null
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(UserName)} cannot be null");
                }

                // If the value does not have any characters or has whitespace
                if (value.Trim() == String.Empty)
                {
                    throw new ArgumentException($"{nameof(UserName)} must have some text");
                }

                // Check the Owner only has characters
                if (IsUserNameValid())
                {
                    userName = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(UserName)} can be up to 20 characters, A-Z and whitespaces only");
                }
                // If the value contains any numbers or special characters - throws ArgumentException


                userName = value;
            }
        }

        /// <summary>
        /// Checks if the UserName is less than or equal to 20 characters, A - Z 
        /// and whitespace characters are allowed
        /// </summary>
        /// <returns></returns>
        private bool IsUserNameValid()
        {
            char[] validCharacters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j'
                , 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x'
                , 'y', 'z' };

            userName = userName.ToLower(); // Only need to compare to one casting

            const int MaxLengthUserName = 20;

            if (userName.Length > MaxLengthUserName)
            {
                return false;
            }

            foreach (char letter in userName)
            {
                if (letter != ' ' && !validCharacters.Contains(letter))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The amount of books that the user has read.
        /// </summary>
        public int Books { get; private set; }

        /// <summary>
        /// The amount of hours that the user spent reading.
        /// </summary>
        public int Hours { get; private set; }

        /// <summary>
        /// Add a specified amount of books to the user's account
        /// </summary>
        /// <param name="amtbooks">The positive amount to 
        /// number of books read</param>
        /// <returns>The new amount of books read after deposit</returns>
        public int DepositBooks(int amtbooks)
        {
            if (amtbooks <= 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amtbooks)} must be more than 0");
            }
            Books += amtbooks;
            return Books;
        }

        /// <summary>
        /// Add a specified amount of hours spent reading to the user's account
        /// </summary>
        /// <param name="amthours">The positive amount to 
        /// number of hours spent reading</param>
        /// <returns>The new amount of hours spent reading</returns>
        public int DepositHours(int amthours)
        {
            if (amthours <= 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amthours)} must be more than 0");
            }
            Hours += amthours;
            return Hours;
        }
    }
}

