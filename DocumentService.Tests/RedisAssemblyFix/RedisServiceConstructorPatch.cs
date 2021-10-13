using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using DocumentService.Services;
using HarmonyLib;

namespace DocumentService.Tests.RedisAssemblyFix
{
    [Harmony]
    internal class RedisServiceConstructorPatch
    {
        private static MethodBase TargetMethod() => AccessTools.Constructor(typeof(RedisService), new []{ typeof(string), typeof(int)});

        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instr) =>
            new[]
            {
                //IL_0007: nop
                new CodeInstruction(OpCodes.Nop),
                
                //IL_0008: ldarg.0      // this
                new CodeInstruction(OpCodes.Ldarg_0),
                //IL_0009: newobj       instance void DocumentService.Services.RedisDatabaseMock::.ctor()
                new CodeInstruction(OpCodes.Newobj, AccessTools.Constructor(typeof(RedisDatabaseMock))),
                //IL_000e: stfld        class [StackExchange.Redis.Extensions.Core]StackExchange.Redis.Extensions.Core.Abstractions.IRedisDatabase DocumentService.Services.RedisService::_db
                new CodeInstruction(OpCodes.Stfld, AccessTools.Field(typeof(RedisService), "_db")),
                
                //IL_0013: ret
                new CodeInstruction(OpCodes.Ret)
            };
    }
}