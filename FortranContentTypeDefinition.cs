using Microsoft.VisualStudio.LanguageServer.Client;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace FortranLanguageClient
{
    public class FortranContentDefinition
    {
        [Export]
        [Name("fortran")]
        [BaseDefinition(CodeRemoteContentDefinition.CodeRemoteContentTypeName)]
        internal static ContentTypeDefinition FortranContentTypeDefinition;

        [Export]
        [FileExtension(".f")]
        [ContentType("fortran")]
        internal static FileExtensionToContentTypeDefinition FortranFileExtensionDefinitionF;

        [Export]
        [FileExtension(".f77")]
        [ContentType("fortran")]
        internal static FileExtensionToContentTypeDefinition FortranFileExtensionDefinitionF77;

        [Export]
        [FileExtension(".f90")]
        [ContentType("fortran")]
        internal static FileExtensionToContentTypeDefinition FortranFileExtensionDefinitionF90;

        [Export]
        [FileExtension(".f95")]
        [ContentType("fortran")]
        internal static FileExtensionToContentTypeDefinition FortranFileExtensionDefinitionF95;

        [Export]
        [FileExtension(".f03")]
        [ContentType("fortran")]
        internal static FileExtensionToContentTypeDefinition FortranFileExtensionDefinitionF03;

        [Export]
        [FileExtension(".f08")]
        [ContentType("fortran")]
        internal static FileExtensionToContentTypeDefinition FortranFileExtensionDefinitionF08;

        [Export]
        [FileExtension(".for")]
        [ContentType("fortran")]
        internal static FileExtensionToContentTypeDefinition FortranFileExtensionDefinitionFOR;

        [Export]
        [FileExtension(".fpp")]
        [ContentType("fortran")]
        internal static FileExtensionToContentTypeDefinition FortranFileExtensionDefinitionFPP;
    }
}
