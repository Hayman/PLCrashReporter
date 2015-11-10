using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace CrashReporter
{
	[Native]
	public enum PLCrashReporterSignalHandlerType : nuint
	{
		Bsd = 0,
		Mach = 1
	}

	[Native]
	public enum PLCrashReporterSymbolicationStrategy : nuint
	{
		None = 0,
		SymbolTable = 1 << 0,
		ObjC = 1 << 1,
		All = (SymbolTable | ObjC)
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct PLCrashReporterCallbacks
	{
		public ushort version;

		public unsafe void* context;

		public unsafe PLCrashReporterPostCrashSignalCallback* handleSignal;
	}

	public enum PLCrashReportProcessorTypeEncoding : uint
	{
		Unknown = 0,
		Mach = 1
	}

	public enum PLCrashReportOperatingSystem : uint
	{
		MacOSX = 0,
		iPhoneOS = 1,
		iPhoneSimulator = 2,
		Unknown = 3
	}

	public enum PLCrashReportArchitecture : uint
	{
		X8632 = 0,
		X8664 = 1,
		ARMv6 = 2,
		Arm = ARMv6,
		Ppc = 3,
		Ppc64 = 4,
		ARMv7 = 5,
		Unknown = 6
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct PLCrashReportFileHeader
	{
		public sbyte[] magic;

		public byte version;

		public byte[] data;
	}

	public enum PLCrashReportTextFormat : uint
	{
		PLCrashReportTextFormatiOS = 0
	}

	public enum PLCrashReporterError : uint
	{
		rashReporterErrorUnknown = 0,
		rashReporterErrorOperatingSystem = 1,
		rashReporterErrorCrashReportInvalid = 2,
		rashReporterErrorResourceBusy = 3,
		RashReporterErrorNotFound = 4,
		RashReporterErrorInsufficientMemory = 4
	}
}
