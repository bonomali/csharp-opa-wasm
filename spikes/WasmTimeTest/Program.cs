﻿using System;
using System.Linq;
using Wasmtime;
using Wasmtime.Exports;
using Wasmtime.Externs;
using Wasmtime.Imports;

namespace WasmTimeTest
{
	class Program
	{
		static void Main(string[] args)
		{
			using var engine = new Engine();
			using var store = engine.CreateStore();
			using var module = store.CreateModule("policy.wasm");

			var opaPolicy = module.CreateOpaPolicy();

			opaPolicy.SetData(@"{""world"": ""world""}");

			string input = @"{""message"": ""world""}";
			string output = opaPolicy.Evaluate(input);

			Console.WriteLine($"eval output: {output}");
			Console.Read();
		}
	}
}
