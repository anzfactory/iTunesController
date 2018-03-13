using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anz.Editor.iTunes
{
	public class Settings
	{
		public enum File {
			Data,
			iTunesShellScript
		}
	}

	public static class SettingsExt
	{
		public static string FullPath(this Settings.File self)
		{
			switch (self) {
				case Settings.File.Data:
					return UnityEngine.Application.dataPath + "/Editor/iTunesController/Data.asset";
				case Settings.File.iTunesShellScript:
					return UnityEngine.Application.dataPath + "/Editor/iTunesController/itunes.sh";
				default: return "";
			}
		}

		public static string AssetPath(this Settings.File self)
		{
			switch (self) {
				case Settings.File.Data:
					return "Assets/Editor/iTunesController/Data.asset";
				default: return "";
			}
		}
	}
}

