﻿namespace Eossyn.Infrastructure.Managers
{
    using System;
    using System.Linq;
    using Models;
    using Core.Web;
    using Data.Repositories;
    using Utilities;

    public class UserSessionManager : IUserSessionManager
    {
        private IUserSessionRepository _userSessionRepo;
        private ISessionUtility _sessionUtil;

        public UserSessionManager(IUserSessionRepository userSessionRepo, ISessionUtility sessionUtil)
        {
            _userSessionRepo = userSessionRepo;
            _sessionUtil = sessionUtil;
        }

        public UserSession CurrentUserSession
        {
            get
            {
                return _sessionUtil.FetchItem<UserSession>(SessionKeys.USERSESSION_KEY);
            }
            set
            {
                _sessionUtil.AddItem(SessionKeys.USERSESSION_KEY, value);
            }
        }

        public UserSession FetchCurrentUserSession()
        {
            return CurrentUserSession;
        }

        UserSession FetchMostRecentUserSession(Guid userId)
        {
            return _userSessionRepo.FetchMostRecentUserSession(userId);
        }

        public bool UserSessionExists(Guid userId)
        {
            var activeUserSession = _userSessionRepo.FetchActiveUserSessionByUserId(userId);
            return activeUserSession != null;
        }

        public void UpdateCurrentCharacter(Guid userCharacterId)
        {
            var userSession = CurrentUserSession;
            userSession.CurrentUserCharacterId = userCharacterId;
            CurrentUserSession = userSession;
            _userSessionRepo.UpdateCurrentCharacter(userSession.UserSessionId, userSession.CurrentUserCharacterId);
        }

        public void UpdateCurrentWorld(Guid worldId)
        {
            var userSession = CurrentUserSession;
            userSession.CurrentWorldId = worldId;
            CurrentUserSession = userSession;
            _userSessionRepo.UpdateCurrentWorld(userSession.UserSessionId, userSession.CurrentWorldId);
        }

        public void CreateUserSession(Guid userId, Guid userCharacterId, Guid worldId)
        {
            var userSession = new UserSession
            {
                UserSessionId = Guid.NewGuid(),
                UserId = userId,
                CurrentUserCharacterId = userCharacterId,
                CurrentWorldId = worldId,
                CreatedTime = DateTime.Now,
                LastUpdated = DateTime.Now,
                IsActive = true
            };
            CurrentUserSession = userSession;
            _userSessionRepo.Insert(userSession);
        }

        public void UpdateUserSession()
        {
            var userSession = CurrentUserSession;
            userSession.LastUpdated = DateTime.Now;
            CurrentUserSession = userSession;
            _userSessionRepo.UpdateUserSession(userSession.UserSessionId);
        }

        public void EndUserSession()
        {
            var userSession = CurrentUserSession;
            if (CurrentUserSession != null)
            {
                _userSessionRepo.EndUserSession(CurrentUserSession.UserSessionId);
                CurrentUserSession = null;
            }
        }
    }
}
