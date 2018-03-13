using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anz.Editor.iTunes
{
	public class Settings
	{
		public enum File {
			Config,
			iTunesShellScript
		}
	}

	public static class SettingsExt
	{
		public static string FullPath(this Settings.File self)
		{
			switch (self) {
				case Settings.File.Config:
					return UnityEngine.Application.dataPath + "/Editor/iTunesController/Config.asset";
				case Settings.File.iTunesShellScript:
					return UnityEngine.Application.dataPath + "/Editor/iTunesController/itunes.sh";
				default: return "";
			}
		}

		public static string AssetPath(this Settings.File self)
		{
			switch (self) {
				case Settings.File.Config:
					return "Assets/Editor/iTunesController/Config.asset";
				default: return "";
			}
		}
	}
}

