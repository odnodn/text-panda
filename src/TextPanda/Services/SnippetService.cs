using AutoHotkey.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using TextPanda.Models;

namespace TextPanda.Services
{
    public class SnippetService : ISnippetService
    {
        static readonly AutoHotkeyEngine _ahk = AutoHotkeyEngine.Instance;

        public void ApplySnippets(IReadOnlyList<Snippet> snippets)
        {
            _ahk.Reset();

            foreach (var snippet in snippets.Where(CanBeApplied))
            {
                _ahk.ExecRaw(MapToAhkHotString(snippet));
            }

            _ahk.ExecRaw(@"~::~"); // reassign a key to itself as the hotstrings wont work without a hotkey being set.
        }

        bool CanBeApplied(Snippet snippet)
        {
            return snippet.IsEnabled && String.IsNullOrWhiteSpace(snippet.Shortcut) == false
                 && String.IsNullOrWhiteSpace(snippet.ReplaceWith) == false;
        }

        string MapToAhkHotString(Snippet snippet)
        {
            return $@":{(snippet.ReplaceMode == ReplaceMode.Auto ? "*" : String.Empty)}:{snippet.Shortcut}::
(
{snippet.ReplaceWith}
)";
        }
    }
}
