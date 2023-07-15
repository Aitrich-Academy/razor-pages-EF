using JobPortalApplication.Models;
using JobPortalApplication.Enums;
using JobPortalApplication.Exceptions;
using JobPortalApplication.Interfaces;


namespace JobPortalApplication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private HireMeNowDbContext _context;
        public UserRepository(HireMeNowDbContext context)
        {
            _context = context;
        }

        public User getById(Guid userId)
        {
           User user= _context.Users.Where(e=>e.Id==userId).FirstOrDefault();
            return user;
        }

        public User Login(string email, string password)
        {
            User res= _context.Users.Where(e=>e.Email==email && e.Password==password).FirstOrDefault();
            return res;

		}

        public User register(User user)
        {
           
            user.Role = Roles.JobSeeker.ToString();
            _context.Users.Add(user);
            _context.SaveChanges();
			

			return user;
            //if (_context._context.Users.Find(e => e.Email == user.Email) == null)
            //{
            //    _context._context.Users.Add(user);
            //return user;
            //}
            //else
            //{
            //    throw new UserAlreadyExistException(user.Email);
            //}
        }

        public User Update(User updatedUser)
        {
            var userToUpdate = _context.Users.Find(updatedUser.Id);
            if (userToUpdate != null)
            {
                // Modify the properties of the item at the found index
               userToUpdate.About = updatedUser.About ??userToUpdate.About;
               userToUpdate.Experiences = updatedUser.Experiences ??userToUpdate.Experiences;
                //_context.Users[indexToUpdate].Educations = updatedUser.Educations ??userToUpdate.Educations;
               userToUpdate.Skills = updatedUser.Skills ??userToUpdate.Skills;
               userToUpdate.FirstName = updatedUser.FirstName??userToUpdate.FirstName;
               userToUpdate.LastName = updatedUser.LastName??userToUpdate.LastName;
               userToUpdate.Location = updatedUser.Location??userToUpdate.Location;
               userToUpdate.Gender = updatedUser.Gender??userToUpdate.Gender;
               userToUpdate.Phone = updatedUser.Phone==null?userToUpdate.Phone : updatedUser.Phone;

            }
            else
            {
                throw new NotFoundException("User Not Found");
            }

            return userToUpdate;
        }

        public User memberRegister(User user)
        {
            user.Id = Guid.NewGuid();
            user.Role = Roles.CompanyMember.ToString();

            if (_context.Users.Where(e => e.Email == user.Email).Count()<=0)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            else
            {
                throw new UserAlreadyExistException(user.Email);
            }
        }

        public List<User> memberListing(Guid companyId) 
        {
            var memberList = _context.Users.Where(e=>e.Role==Roles.CompanyMember.ToString() && e.CompanyId==companyId).ToList();
            return memberList;
        }

		public User getuser()
		{
			return _context.Users.FirstOrDefault();
		}
	

		public List<User> getAllUsers()
		{
            return _context.Users.ToList();
		}

        public void memberDeleteById(Guid id)
        {
            User user = _context.Users.Find(id);
            if (user!=null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }

    

}
