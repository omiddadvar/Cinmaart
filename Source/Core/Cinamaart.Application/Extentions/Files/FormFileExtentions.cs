﻿using Cinamaart.Domain.Common.Enums;
using Microsoft.AspNetCore.Http;

namespace Cinamaart.Application.Extentions.Files
{
    public static class FormFileExtentions
    {
        public static string GetExtention(this IFormFile formFile)
        {
            return Path.GetExtension(formFile.FileName);
        }
        public static DocumentTypeEnum GetDocType(this IFormFile formFile)
        {
            string fileExtention = formFile.GetExtention();
            return _getDocType(fileExtention);
        }
        private static DocumentTypeEnum _getDocType(string fileExtention)
        {
            fileExtention = fileExtention.ToUpper();
            foreach (DocumentTypeEnum documentType in Enum.GetValues(typeof(DocumentTypeEnum)))
            {
                if (nameof(documentType) == fileExtention)
                    return documentType;
            }
            return DocumentTypeEnum.Unknown;
        }
    }
}
