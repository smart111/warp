﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Warp.WarpAnalytics {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WarpAnalytics.IWarpAnalytics")]
    public interface IWarpAnalytics {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarpAnalytics/GetLatestVersion", ReplyAction="http://tempuri.org/IWarpAnalytics/GetLatestVersionResponse")]
        System.Version GetLatestVersion();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarpAnalytics/GetLatestVersion", ReplyAction="http://tempuri.org/IWarpAnalytics/GetLatestVersionResponse")]
        System.Threading.Tasks.Task<System.Version> GetLatestVersionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarpAnalytics/LogProcessingMotion", ReplyAction="http://tempuri.org/IWarpAnalytics/LogProcessingMotionResponse")]
        string LogProcessingMotion(
                    System.Guid secret, 
                    string dateTime, 
                    float pixelX, 
                    float pixelY, 
                    float pixelAngle, 
                    float binTimes, 
                    bool useGain, 
                    int width, 
                    int height, 
                    int nframes, 
                    float rangeMin, 
                    float rangeMax, 
                    int bfactor, 
                    int gridWidth, 
                    int gridHeight, 
                    int gridDepth, 
                    float meanFrameShift);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarpAnalytics/LogProcessingMotion", ReplyAction="http://tempuri.org/IWarpAnalytics/LogProcessingMotionResponse")]
        System.Threading.Tasks.Task<string> LogProcessingMotionAsync(
                    System.Guid secret, 
                    string dateTime, 
                    float pixelX, 
                    float pixelY, 
                    float pixelAngle, 
                    float binTimes, 
                    bool useGain, 
                    int width, 
                    int height, 
                    int nframes, 
                    float rangeMin, 
                    float rangeMax, 
                    int bfactor, 
                    int gridWidth, 
                    int gridHeight, 
                    int gridDepth, 
                    float meanFrameShift);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarpAnalytics/LogProcessingCTF", ReplyAction="http://tempuri.org/IWarpAnalytics/LogProcessingCTFResponse")]
        string LogProcessingCTF(
                    System.Guid secret, 
                    string dateTime, 
                    float pixelX, 
                    float pixelY, 
                    float pixelAngle, 
                    float binTimes, 
                    bool useGain, 
                    int width, 
                    int height, 
                    int nframes, 
                    int window, 
                    float rangeMin, 
                    float rangeMax, 
                    int voltage, 
                    float cs, 
                    float cc, 
                    float illumAngle, 
                    float energySpread, 
                    float thickness, 
                    float amplitude, 
                    bool doPhase, 
                    bool doIce, 
                    bool useMovieSum, 
                    float zmin, 
                    float zmax, 
                    int gridWidth, 
                    int gridHeight, 
                    int gridDepth, 
                    float defocus, 
                    float astigmatism, 
                    float astigmatismAngle, 
                    float phase, 
                    float resolution);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarpAnalytics/LogProcessingCTF", ReplyAction="http://tempuri.org/IWarpAnalytics/LogProcessingCTFResponse")]
        System.Threading.Tasks.Task<string> LogProcessingCTFAsync(
                    System.Guid secret, 
                    string dateTime, 
                    float pixelX, 
                    float pixelY, 
                    float pixelAngle, 
                    float binTimes, 
                    bool useGain, 
                    int width, 
                    int height, 
                    int nframes, 
                    int window, 
                    float rangeMin, 
                    float rangeMax, 
                    int voltage, 
                    float cs, 
                    float cc, 
                    float illumAngle, 
                    float energySpread, 
                    float thickness, 
                    float amplitude, 
                    bool doPhase, 
                    bool doIce, 
                    bool useMovieSum, 
                    float zmin, 
                    float zmax, 
                    int gridWidth, 
                    int gridHeight, 
                    int gridDepth, 
                    float defocus, 
                    float astigmatism, 
                    float astigmatismAngle, 
                    float phase, 
                    float resolution);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarpAnalytics/LogProcessingBoxNet", ReplyAction="http://tempuri.org/IWarpAnalytics/LogProcessingBoxNetResponse")]
        string LogProcessingBoxNet(System.Guid secret, string dateTime, int version, int diameter, float minimumScore, float minimumDistance, bool doExport, int exportBoxSize, bool exportInvert, bool exportNormalize, bool doMasking, int nparticles);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarpAnalytics/LogProcessingBoxNet", ReplyAction="http://tempuri.org/IWarpAnalytics/LogProcessingBoxNetResponse")]
        System.Threading.Tasks.Task<string> LogProcessingBoxNetAsync(System.Guid secret, string dateTime, int version, int diameter, float minimumScore, float minimumDistance, bool doExport, int exportBoxSize, bool exportInvert, bool exportNormalize, bool doMasking, int nparticles);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarpAnalytics/LogEnvironment", ReplyAction="http://tempuri.org/IWarpAnalytics/LogEnvironmentResponse")]
        string LogEnvironment(System.Guid secret, string dateTime, string version, int cpuCores, int cpuClock, int cpuMemory, int gpuCores, int gpuMemory, string gpuName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWarpAnalytics/LogEnvironment", ReplyAction="http://tempuri.org/IWarpAnalytics/LogEnvironmentResponse")]
        System.Threading.Tasks.Task<string> LogEnvironmentAsync(System.Guid secret, string dateTime, string version, int cpuCores, int cpuClock, int cpuMemory, int gpuCores, int gpuMemory, string gpuName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWarpAnalyticsChannel : Warp.WarpAnalytics.IWarpAnalytics, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WarpAnalyticsClient : System.ServiceModel.ClientBase<Warp.WarpAnalytics.IWarpAnalytics>, Warp.WarpAnalytics.IWarpAnalytics {
        
        public WarpAnalyticsClient() {
        }
        
        public WarpAnalyticsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WarpAnalyticsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WarpAnalyticsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WarpAnalyticsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Version GetLatestVersion() {
            return base.Channel.GetLatestVersion();
        }
        
        public System.Threading.Tasks.Task<System.Version> GetLatestVersionAsync() {
            return base.Channel.GetLatestVersionAsync();
        }
        
        public string LogProcessingMotion(
                    System.Guid secret, 
                    string dateTime, 
                    float pixelX, 
                    float pixelY, 
                    float pixelAngle, 
                    float binTimes, 
                    bool useGain, 
                    int width, 
                    int height, 
                    int nframes, 
                    float rangeMin, 
                    float rangeMax, 
                    int bfactor, 
                    int gridWidth, 
                    int gridHeight, 
                    int gridDepth, 
                    float meanFrameShift) {
            return base.Channel.LogProcessingMotion(secret, dateTime, pixelX, pixelY, pixelAngle, binTimes, useGain, width, height, nframes, rangeMin, rangeMax, bfactor, gridWidth, gridHeight, gridDepth, meanFrameShift);
        }
        
        public System.Threading.Tasks.Task<string> LogProcessingMotionAsync(
                    System.Guid secret, 
                    string dateTime, 
                    float pixelX, 
                    float pixelY, 
                    float pixelAngle, 
                    float binTimes, 
                    bool useGain, 
                    int width, 
                    int height, 
                    int nframes, 
                    float rangeMin, 
                    float rangeMax, 
                    int bfactor, 
                    int gridWidth, 
                    int gridHeight, 
                    int gridDepth, 
                    float meanFrameShift) {
            return base.Channel.LogProcessingMotionAsync(secret, dateTime, pixelX, pixelY, pixelAngle, binTimes, useGain, width, height, nframes, rangeMin, rangeMax, bfactor, gridWidth, gridHeight, gridDepth, meanFrameShift);
        }
        
        public string LogProcessingCTF(
                    System.Guid secret, 
                    string dateTime, 
                    float pixelX, 
                    float pixelY, 
                    float pixelAngle, 
                    float binTimes, 
                    bool useGain, 
                    int width, 
                    int height, 
                    int nframes, 
                    int window, 
                    float rangeMin, 
                    float rangeMax, 
                    int voltage, 
                    float cs, 
                    float cc, 
                    float illumAngle, 
                    float energySpread, 
                    float thickness, 
                    float amplitude, 
                    bool doPhase, 
                    bool doIce, 
                    bool useMovieSum, 
                    float zmin, 
                    float zmax, 
                    int gridWidth, 
                    int gridHeight, 
                    int gridDepth, 
                    float defocus, 
                    float astigmatism, 
                    float astigmatismAngle, 
                    float phase, 
                    float resolution) {
            return base.Channel.LogProcessingCTF(secret, dateTime, pixelX, pixelY, pixelAngle, binTimes, useGain, width, height, nframes, window, rangeMin, rangeMax, voltage, cs, cc, illumAngle, energySpread, thickness, amplitude, doPhase, doIce, useMovieSum, zmin, zmax, gridWidth, gridHeight, gridDepth, defocus, astigmatism, astigmatismAngle, phase, resolution);
        }
        
        public System.Threading.Tasks.Task<string> LogProcessingCTFAsync(
                    System.Guid secret, 
                    string dateTime, 
                    float pixelX, 
                    float pixelY, 
                    float pixelAngle, 
                    float binTimes, 
                    bool useGain, 
                    int width, 
                    int height, 
                    int nframes, 
                    int window, 
                    float rangeMin, 
                    float rangeMax, 
                    int voltage, 
                    float cs, 
                    float cc, 
                    float illumAngle, 
                    float energySpread, 
                    float thickness, 
                    float amplitude, 
                    bool doPhase, 
                    bool doIce, 
                    bool useMovieSum, 
                    float zmin, 
                    float zmax, 
                    int gridWidth, 
                    int gridHeight, 
                    int gridDepth, 
                    float defocus, 
                    float astigmatism, 
                    float astigmatismAngle, 
                    float phase, 
                    float resolution) {
            return base.Channel.LogProcessingCTFAsync(secret, dateTime, pixelX, pixelY, pixelAngle, binTimes, useGain, width, height, nframes, window, rangeMin, rangeMax, voltage, cs, cc, illumAngle, energySpread, thickness, amplitude, doPhase, doIce, useMovieSum, zmin, zmax, gridWidth, gridHeight, gridDepth, defocus, astigmatism, astigmatismAngle, phase, resolution);
        }
        
        public string LogProcessingBoxNet(System.Guid secret, string dateTime, int version, int diameter, float minimumScore, float minimumDistance, bool doExport, int exportBoxSize, bool exportInvert, bool exportNormalize, bool doMasking, int nparticles) {
            return base.Channel.LogProcessingBoxNet(secret, dateTime, version, diameter, minimumScore, minimumDistance, doExport, exportBoxSize, exportInvert, exportNormalize, doMasking, nparticles);
        }
        
        public System.Threading.Tasks.Task<string> LogProcessingBoxNetAsync(System.Guid secret, string dateTime, int version, int diameter, float minimumScore, float minimumDistance, bool doExport, int exportBoxSize, bool exportInvert, bool exportNormalize, bool doMasking, int nparticles) {
            return base.Channel.LogProcessingBoxNetAsync(secret, dateTime, version, diameter, minimumScore, minimumDistance, doExport, exportBoxSize, exportInvert, exportNormalize, doMasking, nparticles);
        }
        
        public string LogEnvironment(System.Guid secret, string dateTime, string version, int cpuCores, int cpuClock, int cpuMemory, int gpuCores, int gpuMemory, string gpuName) {
            return base.Channel.LogEnvironment(secret, dateTime, version, cpuCores, cpuClock, cpuMemory, gpuCores, gpuMemory, gpuName);
        }
        
        public System.Threading.Tasks.Task<string> LogEnvironmentAsync(System.Guid secret, string dateTime, string version, int cpuCores, int cpuClock, int cpuMemory, int gpuCores, int gpuMemory, string gpuName) {
            return base.Channel.LogEnvironmentAsync(secret, dateTime, version, cpuCores, cpuClock, cpuMemory, gpuCores, gpuMemory, gpuName);
        }
    }
}
