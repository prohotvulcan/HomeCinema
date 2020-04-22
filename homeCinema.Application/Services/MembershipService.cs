using homeCinema.Application.Interfaces;
using homeCinema.Application.Utilities;
using homeCinema.Data.EF;
using homeCinema.Data.Entities;
using homeCinema.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace homeCinema.Application.Services
{
    public class MembershipService : IMembershipService
    {
        #region Variables
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<UserRole> _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncryptionService _encryptionService;
        #endregion

        public MembershipService(IRepository<User> userRepository,
            IRepository<Role> roleRepository,
            IRepository<UserRole> userRoleRepository,
            IUnitOfWork unitOfWork,
            IEncryptionService encryptionService)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
            _encryptionService = encryptionService;
        }

        #region Implement methods
        public User CreateUser(string username, string email, string password, int[] roles)
        {
            var userExisting = _userRepository.GetSingleByUsername(username);
            if (userExisting != null)
            {
                throw new Exception("Username is already in use.");
            }

            var passwordSalt = _encryptionService.CreateSalt();
            User user = new User
            {
                Email = email,
                UserName = username,
                Salt = passwordSalt,
                HashedPassword = _encryptionService.EncryptPassword(password, passwordSalt),
                IsLocked = false,
                DateCreated = DateTime.Now
            };

            _userRepository.Add(user);
            _unitOfWork.Commit();

            if (roles != null && roles.Length > 0)
            {
                foreach (int id in roles)
                {
                    AddUserToRole(user, id);
                }
            }
            _unitOfWork.Commit();
            return user;
        }

        public User GetUser(int id)
        {
            return _userRepository.GetSingle(id);
        }

        public List<Role> GetUserRoles(string username)
        {
            List<Role> roles = new List<Role>();
            var existingUser = _userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                foreach (var userRole in existingUser.UserRoles)
                {
                    roles.Add(userRole.Role);
                }
            }
            return roles.Distinct().ToList();
        }

        public MembershipContext ValidateUser(string username, string password)
        {
            MembershipContext context = new MembershipContext();
            var userExisting = _userRepository.GetSingleByUsername(username);
            if (userExisting != null && IsUserValid(userExisting, password))
            {
                var userRoles = GetUserRoles(username);
                context.User = userExisting;
                var identity = new GenericIdentity(username);
                context.Principal = new GenericPrincipal(identity, userRoles.Select(x => x.Name).ToArray());
            }
            return context;
        }
        #endregion

        #region Private methods
        public void AddUserToRole(User user, int roleId)
        {
            var role = _roleRepository.GetSingle(roleId);
            if (role == null)
            {
                throw new Exception("Role doesn't exist.");
            }

            UserRole userRole = new UserRole
            {
                RoleId = roleId,
                UserId = user.Id
            };
            _userRoleRepository.Add(userRole);
        }

        private bool IsPasswordValid(User user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
        }

        private bool IsUserValid(User user, string password)
        {
            if (IsPasswordValid(user, password))
            {
                return !user.IsLocked;
            }
            return false;
        }
        #endregion
    }
}
