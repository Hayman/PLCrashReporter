using System;
using CoreFoundation;
using CrashReporter;
using Foundation;

namespace CrashReporter
{
    // @interface PLCrashReporterConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface PLCrashReporterConfig
    {
        // +(instancetype)defaultConfiguration;
        [Static]
        [Export("defaultConfiguration")]
        PLCrashReporterConfig DefaultConfiguration();

        // -(instancetype)initWithSignalHandlerType:(PLCrashReporterSignalHandlerType)signalHandlerType symbolicationStrategy:(PLCrashReporterSymbolicationStrategy)symbolicationStrategy;
        [Export("initWithSignalHandlerType:symbolicationStrategy:")]
        IntPtr Constructor(PLCrashReporterSignalHandlerType signalHandlerType, PLCrashReporterSymbolicationStrategy symbolicationStrategy);

        // @property (readonly, nonatomic) PLCrashReporterSignalHandlerType signalHandlerType;
        [Export("signalHandlerType")]
        PLCrashReporterSignalHandlerType SignalHandlerType { get; }

        // @property (readonly, nonatomic) PLCrashReporterSymbolicationStrategy symbolicationStrategy;
        [Export("symbolicationStrategy")]
        PLCrashReporterSymbolicationStrategy SymbolicationStrategy { get; }
    }

    // @interface PLCrashReporter : NSObject
    [BaseType(typeof(NSObject))]
    interface PLCrashReporter
    {
        // +(PLCrashReporter *)sharedReporter __attribute__((deprecated("")));
        [Static]
        [Export("sharedReporter")]
        [Obsolete("As of PLCrashReporter 1.2, the default reporter instance has been deprecated, and API clients should initialize a crash reporter instance directly.")]
        PLCrashReporter SharedReporter { get; }

        // -(instancetype)initWithConfiguration:(PLCrashReporterConfig *)config;
        [Export("initWithConfiguration:")]
        IntPtr Constructor(PLCrashReporterConfig config);

        // -(BOOL)hasPendingCrashReport;
        [Export("hasPendingCrashReport")]
        //[Verify(MethodToProperty)]
        bool HasPendingCrashReport { get; }

        // -(NSData *)loadPendingCrashReportData;
        [Export("loadPendingCrashReportData")]
        //[Verify(MethodToProperty)]
        NSData LoadPendingCrashReportData();

        // -(NSData *)loadPendingCrashReportDataAndReturnError:(NSError **)outError;
        [Export("loadPendingCrashReportDataAndReturnError:")]
        NSData LoadPendingCrashReportDataAndReturnError(out NSError outError);

        // -(NSData *)generateLiveReportWithThread:(thread_t)thread;
        [Export("generateLiveReportWithThread:")]
        NSData GenerateLiveReportWithThread(uint thread);

        // -(NSData *)generateLiveReportWithThread:(thread_t)thread error:(NSError **)outError;
        [Export("generateLiveReportWithThread:error:")]
        NSData GenerateLiveReportWithThread(uint thread, out NSError outError);

        // -(NSData *)generateLiveReport;
        [Export("generateLiveReport")]
        //[Verify(MethodToProperty)]
        NSData GenerateLiveReport();

        // -(NSData *)generateLiveReportAndReturnError:(NSError **)outError;
        [Export("generateLiveReportAndReturnError:")]
        NSData GenerateLiveReportAndReturnError(out NSError outError);

        // -(BOOL)purgePendingCrashReport;
        [Export("purgePendingCrashReport")]
        //[Verify(MethodToProperty)]
        bool PurgePendingCrashReport();

        // -(BOOL)purgePendingCrashReportAndReturnError:(NSError **)outError;
        [Export("purgePendingCrashReportAndReturnError:")]
        bool PurgePendingCrashReportAndReturnError(out NSError outError);

        // -(BOOL)enableCrashReporter;
        [Export("enableCrashReporter")]
        //[Verify(MethodToProperty)]
        bool EnableCrashReporter { get; }

        // -(BOOL)enableCrashReporterAndReturnError:(NSError **)outError;
        [Export("enableCrashReporterAndReturnError:")]
        bool EnableCrashReporterAndReturnError(out NSError outError);

        // -(void)setCrashCallbacks:(PLCrashReporterCallbacks *)callbacks;
        [Export("setCrashCallbacks:")]
        unsafe void SetCrashCallbacks(PLCrashReporterCallbacks callbacks);
    }

    // @interface PLCrashReportApplicationInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface PLCrashReportApplicationInfo
    {
        // -(id)initWithApplicationIdentifier:(NSString *)applicationIdentifier applicationVersion:(NSString *)applicationVersion applicationMarketingVersion:(NSString *)applicationMarketingVersion;
        [Export("initWithApplicationIdentifier:applicationVersion:applicationMarketingVersion:")]
        IntPtr Constructor(string applicationIdentifier, string applicationVersion, string applicationMarketingVersion);

        // @property (readonly, nonatomic) NSString * applicationIdentifier;
        [Export("applicationIdentifier")]
        string ApplicationIdentifier { get; }

        // @property (readonly, nonatomic) NSString * applicationVersion;
        [Export("applicationVersion")]
        string ApplicationVersion { get; }

        // @property (readonly, nonatomic) NSString * applicationMarketingVersion;
        [Export("applicationMarketingVersion")]
        string ApplicationMarketingVersion { get; }
    }

    // @interface PLCrashReportProcessorInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface PLCrashReportProcessorInfo
    {
        // -(id)initWithTypeEncoding:(PLCrashReportProcessorTypeEncoding)typeEncoding type:(uint64_t)type subtype:(uint64_t)subtype;
        [Export("initWithTypeEncoding:type:subtype:")]
        IntPtr Constructor(PLCrashReportProcessorTypeEncoding typeEncoding, ulong type, ulong subtype);

        // @property (readonly, nonatomic) PLCrashReportProcessorTypeEncoding typeEncoding;
        [Export("typeEncoding")]
        PLCrashReportProcessorTypeEncoding TypeEncoding { get; }

        // @property (readonly, nonatomic) uint64_t type;
        [Export("type")]
        ulong Type { get; }

        // @property (readonly, nonatomic) uint64_t subtype;
        [Export("subtype")]
        ulong Subtype { get; }
    }

    // @interface PLCrashReportBinaryImageInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface PLCrashReportBinaryImageInfo
    {
        // -(id)initWithCodeType:(PLCrashReportProcessorInfo *)processorInfo baseAddress:(uint64_t)baseAddress size:(uint64_t)imageSize name:(NSString *)imageName uuid:(NSData *)uuid;
        [Export("initWithCodeType:baseAddress:size:name:uuid:")]
        IntPtr Constructor(PLCrashReportProcessorInfo processorInfo, ulong baseAddress, ulong imageSize, string imageName, NSData uuid);

        // @property (readonly, nonatomic) PLCrashReportProcessorInfo * codeType;
        [Export("codeType")]
        PLCrashReportProcessorInfo CodeType { get; }

        // @property (readonly, nonatomic) uint64_t imageBaseAddress;
        [Export("imageBaseAddress")]
        ulong ImageBaseAddress { get; }

        // @property (readonly, nonatomic) uint64_t imageSize;
        [Export("imageSize")]
        ulong ImageSize { get; }

        // @property (readonly, nonatomic) NSString * imageName;
        [Export("imageName")]
        string ImageName { get; }

        // @property (readonly, nonatomic) BOOL hasImageUUID;
        [Export("hasImageUUID")]
        bool HasImageUUID { get; }

        // @property (readonly, nonatomic) NSString * imageUUID;
        [Export("imageUUID")]
        string ImageUUID { get; }
    }

    // @interface PLCrashReportSymbolInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface PLCrashReportSymbolInfo
    {
        // -(id)initWithSymbolName:(NSString *)symbolName startAddress:(uint64_t)startAddress endAddress:(uint64_t)endAddress;
        [Export("initWithSymbolName:startAddress:endAddress:")]
        IntPtr Constructor(string symbolName, ulong startAddress, ulong endAddress);

        // @property (readonly, nonatomic) NSString * symbolName;
        [Export("symbolName")]
        string SymbolName { get; }

        // @property (readonly, nonatomic) uint64_t startAddress;
        [Export("startAddress")]
        ulong StartAddress { get; }

        // @property (readonly, nonatomic) uint64_t endAddress;
        [Export("endAddress")]
        ulong EndAddress { get; }
    }

    // @interface PLCrashReportStackFrameInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface PLCrashReportStackFrameInfo
    {
        // -(id)initWithInstructionPointer:(uint64_t)instructionPointer symbolInfo:(PLCrashReportSymbolInfo *)symbolInfo;
        [Export("initWithInstructionPointer:symbolInfo:")]
        IntPtr Constructor(ulong instructionPointer, PLCrashReportSymbolInfo symbolInfo);

        // @property (readonly, nonatomic) uint64_t instructionPointer;
        [Export("instructionPointer")]
        ulong InstructionPointer { get; }

        // @property (readonly, nonatomic) PLCrashReportSymbolInfo * symbolInfo;
        [Export("symbolInfo")]
        PLCrashReportSymbolInfo SymbolInfo { get; }
    }

    // @interface PLCrashReportRegisterInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface PLCrashReportRegisterInfo
    {
        // -(id)initWithRegisterName:(NSString *)registerName registerValue:(uint64_t)registerValue;
        [Export("initWithRegisterName:registerValue:")]
        IntPtr Constructor(string registerName, ulong registerValue);

        // @property (readonly, nonatomic) NSString * registerName;
        [Export("registerName")]
        string RegisterName { get; }

        // @property (readonly, nonatomic) uint64_t registerValue;
        [Export("registerValue")]
        ulong RegisterValue { get; }
    }

    // @interface PLCrashReportThreadInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface PLCrashReportThreadInfo
    {
        // -(id)initWithThreadNumber:(NSInteger)threadNumber stackFrames:(NSArray *)stackFrames crashed:(BOOL)crashed registers:(NSArray *)registers;
        [Export("initWithThreadNumber:stackFrames:crashed:registers:")]
        IntPtr Constructor(nint threadNumber, PLCrashReportStackFrameInfo[] stackFrames, bool crashed, PLCrashReportRegisterInfo[] registers);

        // @property (readonly, nonatomic) NSInteger threadNumber;
        [Export("threadNumber")]
        nint ThreadNumber { get; }

        // @property (readonly, nonatomic) NSArray * stackFrames;
        [Export("stackFrames")]
        PLCrashReportStackFrameInfo[] StackFrames { get; }

        // @property (readonly, nonatomic) BOOL crashed;
        [Export("crashed")]
        bool Crashed { get; }

        // @property (readonly, nonatomic) NSArray * registers;
        [Export("registers")]
        PLCrashReportRegisterInfo[] Registers { get; }
    }

    // @interface PLCrashReportExceptionInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface PLCrashReportExceptionInfo
    {
        // -(id)initWithExceptionName:(NSString *)name reason:(NSString *)reason;
        [Export("initWithExceptionName:reason:")]
        IntPtr Constructor(string name, string reason);

        // -(id)initWithExceptionName:(NSString *)name reason:(NSString *)reason stackFrames:(NSArray *)stackFrames;
        [Export("initWithExceptionName:reason:stackFrames:")]
        IntPtr Constructor(string name, string reason, PLCrashReportStackFrameInfo[] stackFrames);

        // @property (readonly, nonatomic) NSString * exceptionName;
        [Export("exceptionName")]
        string ExceptionName { get; }

        // @property (readonly, nonatomic) NSString * exceptionReason;
        [Export("exceptionReason")]
        string ExceptionReason { get; }

        // @property (readonly, nonatomic) NSArray * stackFrames;
        [Export("stackFrames")]
        PLCrashReportStackFrameInfo[] StackFrames { get; }
    }

    // @interface PLCrashReportMachineInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface PLCrashReportMachineInfo
    {
        // -(id)initWithModelName:(NSString *)modelName processorInfo:(PLCrashReportProcessorInfo *)processorInfo processorCount:(NSUInteger)processorCount logicalProcessorCount:(NSUInteger)logicalProcessorCount;
        [Export("initWithModelName:processorInfo:processorCount:logicalProcessorCount:")]
        IntPtr Constructor(string modelName, PLCrashReportProcessorInfo processorInfo, nuint processorCount, nuint logicalProcessorCount);

        // @property (readonly, nonatomic) NSString * modelName;
        [Export("modelName")]
        string ModelName { get; }

        // @property (readonly, nonatomic) PLCrashReportProcessorInfo * processorInfo;
        [Export("processorInfo")]
        PLCrashReportProcessorInfo ProcessorInfo { get; }

        // @property (readonly, nonatomic) NSUInteger processorCount;
        [Export("processorCount")]
        nuint ProcessorCount { get; }

        // @property (readonly, nonatomic) NSUInteger logicalProcessorCount;
        [Export("logicalProcessorCount")]
        nuint LogicalProcessorCount { get; }
    }

    // @interface PLCrashReportMachExceptionInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface PLCrashReportMachExceptionInfo
    {
        // -(id)initWithType:(uint64_t)type codes:(NSArray *)codes;
        [Export("initWithType:codes:")]
        IntPtr Constructor(ulong type, NSNumber[] codes);

        // @property (readonly, nonatomic) uint64_t type;
        [Export("type")]
        ulong Type { get; }

        // @property (readonly, nonatomic) NSArray * codes;
        [Export("codes")]
        //[Verify(StronglyTypedNSArray)]
        NSNumber[] Codes { get; }
    }

    // @interface PLCrashReportProcessInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface PLCrashReportProcessInfo
    {
        // -(id)initWithProcessName:(NSString *)processName processID:(NSUInteger)processID processPath:(NSString *)processPath processStartTime:(NSDate *)processStartTime parentProcessName:(NSString *)parentProcessName parentProcessID:(NSUInteger)parentProcessID native:(BOOL)native;
        [Export("initWithProcessName:processID:processPath:processStartTime:parentProcessName:parentProcessID:native:")]
        IntPtr Constructor(string processName, nuint processID, string processPath, NSDate processStartTime, string parentProcessName, nuint parentProcessID, bool native);

        // @property (readonly, nonatomic) NSString * processName;
        [Export("processName")]
        string ProcessName { get; }

        // @property (readonly, nonatomic) NSUInteger processID;
        [Export("processID")]
        nuint ProcessID { get; }

        // @property (readonly, nonatomic) NSString * processPath;
        [Export("processPath")]
        string ProcessPath { get; }

        // @property (readonly, nonatomic) NSDate * processStartTime;
        [Export("processStartTime")]
        NSDate ProcessStartTime { get; }

        // @property (readonly, nonatomic) NSString * parentProcessName;
        [Export("parentProcessName")]
        string ParentProcessName { get; }

        // @property (readonly, nonatomic) NSUInteger parentProcessID;
        [Export("parentProcessID")]
        nuint ParentProcessID { get; }

        // @property (readonly, nonatomic) BOOL native;
        [Export("native")]
        bool Native { get; }
    }

    // @interface PLCrashReportSignalInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface PLCrashReportSignalInfo
    {
        // -(id)initWithSignalName:(NSString *)name code:(NSString *)code address:(uint64_t)address;
        [Export("initWithSignalName:code:address:")]
        IntPtr Constructor(string name, string code, ulong address);

        // @property (readonly, nonatomic) NSString * name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSString * code;
        [Export("code")]
        string Code { get; }

        // @property (readonly, nonatomic) uint64_t address;
        [Export("address")]
        ulong Address { get; }
    }

    [BaseType(typeof(NSObject))]
    interface PLCrashReportSystemInfo
    {
        [Export("initWithOperatingSystem:operatingSystemVersion:architecture:timestamp:")]
        IntPtr Constructor(PLCrashReportOperatingSystem operatingSystem, string operatingSystemVersion, PLCrashReportArchitecture architecture, NSDate timestamp);

        [Export("initWithOperatingSystem:operatingSystemVersion:operatingSystemBuild:architecture:timestamp:")]
        IntPtr Constructor(PLCrashReportOperatingSystem operatingSystem, string operatingSystemVersion, string operatingSystemBuild, PLCrashReportArchitecture architecture, NSDate timestamp);

        [Export("initWithOperatingSystem:operatingSystemVersion:operatingSystemBuild:architecture:processorInfo:timestamp:")]
        IntPtr Constructor(PLCrashReportOperatingSystem operatingSystem, string operatingSystemVersion, string operatingSystemBuild, PLCrashReportArchitecture architecture, PLCrashReportProcessorInfo processorInfo, NSDate timestamp);

        [Export("operatingSystem")]
        PLCrashReportOperatingSystem OperatingSystem { get; }

        [Export("operatingSystemVersion")]
        string OperatingSystemVersion { get; }

        [Export("operatingSystemBuild")]
        string OperatingSystemBuild { get; }

        [Export("architecture")]
        PLCrashReportArchitecture Architecture { get; }

        [Export("timestamp")]
        NSDate Timestamp { get; }

        [Export("processorInfo")]
        PLCrashReportProcessorInfo ProcessorInfo { get; }

    }

    [BaseType(typeof(NSObject))]
    interface PLCrashReport
    {
        [Export("initWithData:error:")]
        IntPtr Constructor(NSData encodedData, out NSError outError);

        [Export("imageForAddress:")]
        PLCrashReportBinaryImageInfo ImageForAddress(ulong address);

        [Export("systemInfo")]
        PLCrashReportSystemInfo SystemInfo { get; }

        [Export("hasMachineInfo")]
        bool HasMachineInfo { get; }

        [Export("machineInfo")]
        PLCrashReportMachineInfo MachineInfo { get; }

        [Export("applicationInfo")]
        PLCrashReportApplicationInfo ApplicationInfo { get; }

        [Export("hasProcessInfo")]
        bool HasProcessInfo { get; }

        [Export("processInfo")]
        PLCrashReportProcessInfo ProcessInfo { get; }

        [Export("signalInfo")]
        PLCrashReportSignalInfo SignalInfo { get; }

        [Export("machExceptionInfo")]
        PLCrashReportMachExceptionInfo MachExceptionInfo { get; }

        [Export("threads")]
        PLCrashReportThreadInfo[] Threads { get; }

        [Export("images")]
        PLCrashReportBinaryImageInfo[] Images { get; }

        [Export("hasExceptionInfo")]
        bool HasExceptionInfo { get; }

        [Export("exceptionInfo")]
        PLCrashReportExceptionInfo ExceptionInfo { get; }

    }

    [Protocol, Model]
    interface PLCrashReportFormatter
    {
        [Abstract]
        [Export("formatReport:error:")]
        NSData Error(PLCrashReport report, out NSError outError);

    }

    [BaseType(typeof(NSObject))]
    interface PLCrashReportTextFormatter
    {
        [Static]
        [Export("stringValueForCrashReport:withTextFormat:")]
        string StringValueForCrashReport(PLCrashReport report, PLCrashReportTextFormat textFormat);

        [Export("initWithTextFormat:stringEncoding:")]
        IntPtr Constructor(PLCrashReportTextFormat textFormat, nuint stringEncoding);

    }

    [Static]
    interface Constants
    {
        // extern NSString * PLCrashReporterException;
        [Field("PLCrashReporterException", "__Internal")]
        NSString PLCrashReporterException { get; }

        // extern NSString * PLCrashReporterErrorDomain;
        [Field("PLCrashReporterErrorDomain", "__Internal")]
        NSString PLCrashReporterErrorDomain { get; }

        [Field("PLCrashReportHostOperatingSystem", "__Internal")]
        IntPtr PLCrashReportHostOperatingSystem { get; }

        [Field("PLCrashReportHostArchitecture", "__Internal")]
        IntPtr PLCrashReportHostArchitecture { get; }
    }
}
