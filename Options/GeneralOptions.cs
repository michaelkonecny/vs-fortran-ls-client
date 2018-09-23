using System.ComponentModel;

namespace FortranLanguageClient
{
    internal class GeneralOptions : BaseOptionModel<GeneralOptions>
    {
        [Category("Fortran Language Server path")]
        [DisplayName("Fortran Language Server path")]
        [Description("Absolute path to fortls.exe")]
        [DefaultValue("absolute_path\\to\\fortls.exe")]
        public string FortlsPath { get; set; } = "absolute_path\\to\\fortls.exe";

        [Category("Settings")]
        [DisplayName("Type member symbols")]
        [Description("Include type members in document outline")]
        [DefaultValue(true)]
        public bool TypeMemberSymbols { get; set; } = true;

        [Category("Settings")]
        [DisplayName("Filter autocomplete suggestions")]
        [Description("Filter autocomplete suggestions with variable prefix")]
        [DefaultValue(false)]
        public bool FilterAutocomplete { get; set; } = false;

        [Category("Settings")]
        [DisplayName("Lowercase intrinsics")]
        [Description("Use lowercase for intrinsics and keywords in autocomplete requests")]
        [DefaultValue(false)]
        public bool LowercaseIntrinsics { get; set; } = false;

        [Category("Settings")]
        [DisplayName("Incremental synchronization")]
        [Description("Use incremental synchronization for file changes")]
        [DefaultValue(true)]
        public bool IncrementalSync { get; set; } = true;

        [Category("Settings")]
        [DisplayName("Variable hover")]
        [Description("Show hover information for variables")]
        [DefaultValue(false)]
        public bool VariableHover { get; set; } = false;

        [Category("Settings")]
        [DisplayName("Signature help")]
        [Description("Use signature help instead of snippets when available")]
        [DefaultValue(true)]
        public bool SignatureHelp { get; set; } = true;

    }
}
