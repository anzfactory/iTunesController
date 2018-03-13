using System.IO;
using System.Diagnostics;
using UnityEditor;

namespace Anz.Editor.iTunes
{

	[InitializeOnLoad]
	public static class ITunesController
	{
		public enum Command {
			Play, Pause, Status
		}

		private static Data _data;

		static ITunesController()
		{
			EditorApplication.playModeStateChanged += OnPlayModeStateChanged;

			// 静的なフラグ変数で済ませたいのだけれど、ビルドが終わったり再生するときなんかに都度初期化されるんで...
			// ScriptableObjectとして保存している
			if (!File.Exists(Settings.File.Data.FullPath())) {
				Data.Create();
			}
			_data = AssetDatabase.LoadAssetAtPath<Data>(Settings.File.Data.AssetPath());
		}

		[MenuItem("iTunes/Play %#>")]
		private static void Play()
		{
			Run(Command.Play);
		}

		[MenuItem("iTunes/Pause %#<")]
		private static void Pause()
		{
			Run(Command.Pause);
		}

		private static bool IsPlayingNow()
		{
			var result = Run(Command.Status);
			return result.IndexOf("playing") >= 0;
		}

		private static void OnPlayModeStateChanged(PlayModeStateChange state)
		{

			switch (state) {
				case PlayModeStateChange.ExitingEditMode:
					_data.needsAutoPlay = IsPlayingNow();
					Pause();
					break;
				case PlayModeStateChange.ExitingPlayMode:
					if (_data.needsAutoPlay) {
						Play();
					}
					break;
				default: break;
			}
		}

		private static string Run(Command command)
		{
			var shellFilePath = Settings.File.iTunesShellScript.FullPath();
			var info = new ProcessStartInfo();
			info.FileName = "/bin/sh";
			info.UseShellExecute = false;
			info.CreateNoWindow = false;
			info.RedirectStandardOutput = true;
			info.Arguments = shellFilePath + " " + command.Name();
			var p = new Process();
			p.StartInfo = info;
			p.Start();
			string result = p.StandardOutput.ReadToEnd();
			return result;
		}

	}

	public static class CommandExt
	{
		public static string Name(this Anz.Editor.iTunes.ITunesController.Command self)
		{
			switch (self) {
				case Anz.Editor.iTunes.ITunesController.Command.Play:
					return "play";
				case Anz.Editor.iTunes.ITunesController.Command.Pause:
					return "pause";
				case Anz.Editor.iTunes.ITunesController.Command.Status:
					return "status";
				default:
					return "";
			}
		}
	}
}