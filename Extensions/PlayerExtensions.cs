using System;
using Terraria;
using Yggdrasil.Content.Players;

namespace Yggdrasil.Extensions;

public static class PlayerExtensions
{
    public static YggdrasilPlayer GetYggdrasilPlayer(this Player player) => player.GetModPlayer<YggdrasilPlayer>();

    public static RunemasterPlayer GetRunePlayer(this Player player) => player.GetModPlayer<RunemasterPlayer>();

    public static bool HasEffect<T>(this Player player) => player.GetYggdrasilPlayer().HasEffect<T>();

    public static bool HasEffect(this Player player, Type key) => player.GetYggdrasilPlayer().HasEffect(key);

    public static bool HasEffect(this Player player, string key) => player.GetYggdrasilPlayer().HasEffect(key);

    public static void SetEffect<T>(this Player player) => player.GetYggdrasilPlayer().SetEffect<T>();

    public static void SetEffect(this Player player, Type key) => player.GetYggdrasilPlayer().SetEffect(key);

    public static void SetEffect(this Player player, string key) => player.GetYggdrasilPlayer().SetEffect(key);

    public static bool HasEffect<T>(this YggdrasilPlayer yggdrasilPlayer) => yggdrasilPlayer.EffectsList.Has<T>();

    public static bool HasEffect(this YggdrasilPlayer yggdrasilPlayer, Type key) =>
        yggdrasilPlayer.EffectsList.Has(key);

    public static bool HasEffect(this YggdrasilPlayer yggdrasilPlayer, string key) =>
        yggdrasilPlayer.EffectsList.Has(key);

    public static void SetEffect<T>(this YggdrasilPlayer yggdrasilPlayer) => yggdrasilPlayer.EffectsList.Set<T>();

    public static void SetEffect(this YggdrasilPlayer yggdrasilPlayer, Type key) =>
        yggdrasilPlayer.EffectsList.Set(key);

    public static void SetEffect(this YggdrasilPlayer yggdrasilPlayer, string key) =>
        yggdrasilPlayer.EffectsList.Set(key);
}