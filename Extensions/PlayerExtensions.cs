using System;
using Terraria;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Extensions;

public static class PlayerExtensions
{
    public static YggdrasilPlayer GetYggdrasilPlayer(this Player player) => player.GetModPlayer<YggdrasilPlayer>();

    public static RunePlayer GetRunePlayer(this Player player) => player.GetModPlayer<RunePlayer>();

    public static bool HasEffect<T>(this RunePlayer runePlayer) =>
        runePlayer.Player.GetYggdrasilPlayer().HasEffect<T>();

    public static bool HasEffect(this RunePlayer runePlayer, string effect) =>
        runePlayer.Player.GetYggdrasilPlayer().HasEffect(effect);

    public static void SetEffect<T>(this RunePlayer runePlayer) =>
        runePlayer.Player.GetYggdrasilPlayer().SetEffect<T>();

    public static void SetEffect(this RunePlayer runePlayer, string effect) =>
        runePlayer.Player.GetYggdrasilPlayer().SetEffect(effect);

    public static bool HasEffect<T>(this Player player) =>
        player.GetYggdrasilPlayer().HasEffect<T>();

    public static bool HasEffect(this Player player, Type type) =>
        player.GetYggdrasilPlayer().HasEffect(type);

    public static bool HasEffect(this Player player, string effect) =>
        player.GetYggdrasilPlayer().HasEffect(effect);

    public static void SetEffect<T>(this Player player) =>
        player.GetYggdrasilPlayer().SetEffect<T>();

    public static void SetEffect(this Player player, Type type) =>
        player.GetYggdrasilPlayer().SetEffect(type);

    public static void SetEffect(this Player player, string effect) =>
        player.GetYggdrasilPlayer().SetEffect(effect);

    public static bool HasEffect<T>(this YggdrasilPlayer yggdrasilPlayer) => yggdrasilPlayer.EffectsList.Has<T>();

    public static bool HasEffect(this YggdrasilPlayer yggdrasilPlayer, Type type) =>
        yggdrasilPlayer.EffectsList.Has(type);

    public static bool HasEffect(this YggdrasilPlayer yggdrasilPlayer, string effect) =>
        yggdrasilPlayer.EffectsList.Has(effect);

    public static void SetEffect<T>(this YggdrasilPlayer yggdrasilPlayer) => yggdrasilPlayer.EffectsList.Set<T>();

    public static void SetEffect(this YggdrasilPlayer yggdrasilPlayer, Type type) =>
        yggdrasilPlayer.EffectsList.Set(type);

    public static void SetEffect(this YggdrasilPlayer yggdrasilPlayer, string effect) =>
        yggdrasilPlayer.EffectsList.Set(effect);
}