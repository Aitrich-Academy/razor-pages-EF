using JobPortalApplication.Enums;
using JobPortalApplication.Exceptions;
using JobPortalApplication.Interfaces;
using JobPortalApplication.Models;
using JobPortalApplication.Repositories;
using JobPortalApplication.Exceptions;
using JobPortalApplication.Models;
using JobPortalApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JobPortalApplication.Managers
{
    public class PublicService 
    {
        public User LoggedUser = new User();
        UserRepository userRepository = UserRepository.Instance;
        bool _isLogged = false;
     

       
       public User LoginJobSeeker( string email,string password)
        {
            try
            {
                
                LoggedUser = userRepository.Login(email, password);
                if (LoggedUser.Email != null)
                {
                    Console.WriteLine("Login successful!");
                    _isLogged = true;
                    Console.WriteLine("Welcome " + LoggedUser.FirstName);
                   return LoggedUser;
                }
                else
                {
                    Console.WriteLine("Login failed. Please try again.");
                   return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ServiceException("technical error occured");
            }
        }
        public bool Register(User newJobSeeker)
        {
            try
            {
               
                userRepository.register(newJobSeeker);
                // Register(newJobSeeker);

                Console.WriteLine("Registration successful");
                return true;
            }
            catch (UserAlreadyExistException ex)
            {
                throw ex;
            }
            catch (Exception ex) { throw ex; }
        }

        public User GetUserById(int uid)
        {
            try
            {

                LoggedUser = userRepository.getById(uid);
                return LoggedUser;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ServiceException("technical error occured");
            }
        }

        internal User UpdateUserProfile(User loggedUser)
        {
            return userRepository.Update(loggedUser);
        }

        internal User getLoggedUser()
        {
            return userRepository.getLoggedUser();
        }
        internal void Logout()
        {
             userRepository.logout();
        }

        internal List<User> getCompanyMembers()
        {
            return userRepository.getCompanyMembers();
        }
    }
}
