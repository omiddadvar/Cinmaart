using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Extentions.Files;
using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Entities.Pivots;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Cinamaart.Persistence.Repositories
{
    public class UserProfileRepository(MainDBContext dBContext) : IUserProfileRepository
    {
        public async Task<UserDocument?> AddNewUserProfile(long userId, IFormFile formFile, CancellationToken cancellationToken)
        {
            using var transaction = dBContext.Database.BeginTransaction();
            try
            {
                var document = new Document
                {
                    Name = formFile.FileName,
                    Extention = formFile.GetExtention(),
                    SavedName = Guid.NewGuid().ToString(),
                    DocumentTypeId = (int)formFile.GetDocType()
                };
                await dBContext.SaveChangesAsync();

                var userdocument = new UserDocument
                {
                    UserId = userId,
                    DocumentId = document.Id,
                    Document = document,
                    UserDocumentTypeId = (int)UserDocumentTypeEnum.Profile
                };

                await dBContext.SaveChangesAsync();

                transaction.Commit();

                return userdocument;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        }

        public async Task<UserDocument?> GetProfileUserDocument(long userId, CancellationToken cancellationToken)
        {
            var userDocument = await dBContext.UserDocuments
                .FirstOrDefaultAsync(u => u.Id == userId
                    && u.UserDocumentTypeId == (int)UserDocumentTypeEnum.Profile);
            return userDocument;
        }

        public async Task<bool> RemoveUserProfile(UserDocument userDocument, CancellationToken cancellationToken)
        {
            using var transaction = dBContext.Database.BeginTransaction();
            try
            {
                bool userDocumentExists = await dBContext
                .UserDocuments
                .AnyAsync(u => u.Id == userDocument.Id);

                if (userDocumentExists)
                {
                    dBContext.UserDocuments.Remove(userDocument);
                }

                var document = await dBContext
                    .Documents
                    .FirstOrDefaultAsync(d => d.Id == userDocument.DocumentId);

                if (document is not null)
                {
                    dBContext.Documents.Remove(document);
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        }
    }
}
