namespace AdofaiBin.Serialization.Schema
{
	/// <summary>
	/// Specifies the type of <see cref="ADOFAI.LevelEventType"/>
	/// </summary>
    public enum EventType : byte
    {
	    None,
	    SetSpeed,
	    Twirl,
	    Checkpoint,
	    LevelSettings,
	    SongSettings,
	    TrackSettings,
	    BackgroundSettings,
	    CameraSettings,
	    MiscSettings,
	    EventSettings,
	    DecorationSettings,
	    MoveCamera,
	    CustomBackground,
	    ChangeTrack,
	    ColorTrack,
	    AnimateTrack,
	    RecolorTrack,
	    MoveTrack,
	    AddDecoration,
	    AddText,
	    SetText,
	    Flash,
	    SetHitsound,
	    SetFilter,
	    SetFilterAdvanced,
	    SetPlanetRotation,
	    HallOfMirrors,
	    ShakeScreen,
	    MoveDecorations,
	    PositionTrack,
	    RepeatEvents,
	    Bloom,
	    Hold,
	    SetHoldSound,
	    SetConditionalEvents,
	    ScreenTile,
	    ScreenScroll,
	    EditorComment,
	    Bookmark,
	    CallMethod,
	    AddComponent,
	    PlaySound,
	    MultiPlanet,
	    FreeRoam,
	    FreeRoamTwirl,
	    FreeRoamRemove,
	    FreeRoamWarning,
	    Pause,
	    AutoPlayTiles,
	    Hide,
	    ScaleMargin,
	    ScaleRadius,
	    Multitap,
	    TileDimensions,
	    KillPlayer,
	    ScalePlanets,
	    SetFloorIcon,
	    AddObject,
	    SetObject,
	    SetDefaultText,
	    SetFrameRate,
	    AddParticle,
	    SetParticle,
	    EmitParticle,
	    SetInputEvent
    }

	public static class EventTypeExtensions
	{
		public static bool IsSetting(this EventType eventType) => eventType switch
		{
			EventType.LevelSettings or
			EventType.SongSettings or
			EventType.TrackSettings or
			EventType.BackgroundSettings or
			EventType.CameraSettings or
			EventType.MiscSettings or
			EventType.EventSettings or
			EventType.DecorationSettings => true,
			_ => false
		};
	}
}