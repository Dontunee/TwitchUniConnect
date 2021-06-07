using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitchUniConnect.SharedKernel.Interfaces;
using TwitchUniConnect.SharedKernel.Types;

namespace TwitchUniConnect.Social.Domain.Aggregates.UserAggregate
{
    public class User : Entity<Guid>, IAggregateRoot
    {
        #region Constructors and properties

        private List<User> _colleagues;

        private List<User> _friends;

        private List<FriendRequest> _pendingFriendRequests;

        private User() : base(Guid.NewGuid()) { }

        private User(Guid id ) : base(id)
        {

        }


        public string Username { get; private set; }

        public string Password { get; private set; }

        public UserType Type { get; private set; }

        public Name Name { get; private set; }

        public Faculty Faculty { get; private set; }

        public Class Class { get; private set; }

        public string PhoneNumber { get; private set; }

        public EmailAddress Email { get; private set; }

        public IEnumerable<User> Colleagues
        {
            get
            {
                return _colleagues;
            }
        }

        public IEnumerable<User> Friends
        {
            get
            {
                return _friends;
            }
        }

        public IEnumerable<FriendRequest> PendingFriendRequests
        {
            get
            {
                return _pendingFriendRequests;
            }
        }

        #endregion

        #region Factories

        public static User Create(Guid id, string userName, UserType userType, Name name,
                  EmailAddress email, string phone, string password = null,
                  Faculty faculty = null, Class userClass = null, IEnumerable<User> colleagues = null,
                  IEnumerable<User> friends = null, IEnumerable<FriendRequest> friendRequests = null)
        {
            if (id == default)
                throw new ArgumentException("ID cant be of default value");
            var user = new User(id);
            user.Name = name;
            user.Password = password;
            user.Type = userType;
            user.Email = email;
            user.PhoneNumber = phone;
            user.Faculty = faculty;


            if (userClass != null && userType != UserType.Student)
                throw new ArgumentException("Only students can belong to class");

            user.Class = userClass;
            user._colleagues = colleagues is null ?  new List<User>() : colleagues.ToList();
            user._friends = friends is null ? new List<User>() : friends.ToList();
            user._pendingFriendRequests = friendRequests is null ? new List<FriendRequest>() : friendRequests.ToList();

            return user;
        }
        #endregion

        #region Public Methods

        public void AddFriend(User targetUser)
        {
            var friendRequest = FriendRequest.Create(Id, targetUser.Id);
            targetUser._pendingFriendRequests.Add(friendRequest);
        }

        public void AcceptFriendRequest(User from)
        {
            var friendRequest = _pendingFriendRequests.FirstOrDefault(x => x.FromId == from.Id);
            if (friendRequest is null)
                throw new ArgumentException("Friend request does not exist");

            _friends.Add(from);

            _pendingFriendRequests.Remove(friendRequest);

        }


        public void RejectFriendRequest(Guid id)
        {
            var friendRequest = _pendingFriendRequests.FirstOrDefault(fr => fr.FromId == id);

            if (friendRequest is null)
                throw new ArgumentException("Friend request does not exist");

            _pendingFriendRequests.Remove(friendRequest);

        }


        public void AddColleague(User user)
        {
            _colleagues.Add(user);
        }

        public void RemoveColleague(User user)
        {
            var colleagueToRemove = _colleagues.FirstOrDefault(c => c.Id == user.Id);

            if (colleagueToRemove is null)
                throw new ArgumentException("Colleague to remove deos not exist");

            _colleagues.Remove(colleagueToRemove);
        }


        public void Unfriend(User user)
        {
            var friendToRemove = _friends.FirstOrDefault(fr => fr.Id == user.Id);

            if (friendToRemove is null)
                throw new ArgumentException("Friend not found");

            _friends.Remove(friendToRemove);
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

        public void AddUserFaculty(Faculty faculty)
        {
            if (Faculty != null)
                throw new ArgumentException("The Specified faculty is already assigned to the user");
            Faculty = faculty;
        }

        public void UpdateFaculty(Faculty faculty)
        {
            Faculty = faculty; 
        }

        public void RemoveUserFromFaculty()
        {
            Faculty = null;
        }

        public void AssignToClass(Class studentClass)
        {
            if (Type != UserType.Student)
                throw new ArgumentException("Only students can be added to a class");

            Class = studentClass;
        }

        public void RemoveStudentFromClass()
        {
            if (Class == null)
                throw new ArgumentException("The student does not belong to a class");

            Class = null;
        }
        #endregion
    }
}
