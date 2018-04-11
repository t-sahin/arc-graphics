// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: State.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Rochester.ARTable.Communication {

  /// <summary>Holder for reflection information generated from State.proto</summary>
  public static partial class StateReflection {

    #region Descriptor
    /// <summary>File descriptor for State.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static StateReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgtTdGF0ZS5wcm90bxINY29tbXVuaWNhdGlvbiI3CglTdHJ1Y3R1cmUSDAoE",
            "dHlwZRgBIAEoBRIKCgJpZBgCIAEoBRIQCghwb3NpdGlvbhgDIAMoAiJNCg9T",
            "dHJ1Y3R1cmVzU3RhdGUSDAoEdGltZRgBIAEoAxIsCgpzdHJ1Y3R1cmVzGAIg",
            "AygLMhguY29tbXVuaWNhdGlvbi5TdHJ1Y3R1cmVCIqoCH1JvY2hlc3Rlci5Q",
            "aHlzaWNzLkNvbW11bmljYXRpb25iBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Rochester.ARTable.Communication.Structure), global::Rochester.ARTable.Communication.Structure.Parser, new[]{ "Type", "Id", "Position" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Rochester.ARTable.Communication.StructuresState), global::Rochester.ARTable.Communication.StructuresState.Parser, new[]{ "Time", "Structures" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Structure : pb::IMessage<Structure> {
    private static readonly pb::MessageParser<Structure> _parser = new pb::MessageParser<Structure>(() => new Structure());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Structure> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Rochester.ARTable.Communication.StateReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Structure() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Structure(Structure other) : this() {
      type_ = other.type_;
      id_ = other.id_;
      position_ = other.position_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Structure Clone() {
      return new Structure(this);
    }

    /// <summary>Field number for the "type" field.</summary>
    public const int TypeFieldNumber = 1;
    private int type_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Type {
      get { return type_; }
      set {
        type_ = value;
      }
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 2;
    private int id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    /// <summary>Field number for the "position" field.</summary>
    public const int PositionFieldNumber = 3;
    private static readonly pb::FieldCodec<float> _repeated_position_codec
        = pb::FieldCodec.ForFloat(26);
    private readonly pbc::RepeatedField<float> position_ = new pbc::RepeatedField<float>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<float> Position {
      get { return position_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Structure);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Structure other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Type != other.Type) return false;
      if (Id != other.Id) return false;
      if(!position_.Equals(other.position_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Type != 0) hash ^= Type.GetHashCode();
      if (Id != 0) hash ^= Id.GetHashCode();
      hash ^= position_.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Type != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Type);
      }
      if (Id != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Id);
      }
      position_.WriteTo(output, _repeated_position_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Type != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Type);
      }
      if (Id != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Id);
      }
      size += position_.CalculateSize(_repeated_position_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Structure other) {
      if (other == null) {
        return;
      }
      if (other.Type != 0) {
        Type = other.Type;
      }
      if (other.Id != 0) {
        Id = other.Id;
      }
      position_.Add(other.position_);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Type = input.ReadInt32();
            break;
          }
          case 16: {
            Id = input.ReadInt32();
            break;
          }
          case 26:
          case 29: {
            position_.AddEntriesFrom(input, _repeated_position_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class StructuresState : pb::IMessage<StructuresState> {
    private static readonly pb::MessageParser<StructuresState> _parser = new pb::MessageParser<StructuresState>(() => new StructuresState());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<StructuresState> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Rochester.ARTable.Communication.StateReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StructuresState() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StructuresState(StructuresState other) : this() {
      time_ = other.time_;
      structures_ = other.structures_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StructuresState Clone() {
      return new StructuresState(this);
    }

    /// <summary>Field number for the "time" field.</summary>
    public const int TimeFieldNumber = 1;
    private long time_;
    /// <summary>
    /// timestep
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long Time {
      get { return time_; }
      set {
        time_ = value;
      }
    }

    /// <summary>Field number for the "structures" field.</summary>
    public const int StructuresFieldNumber = 2;
    private static readonly pb::FieldCodec<global::Rochester.ARTable.Communication.Structure> _repeated_structures_codec
        = pb::FieldCodec.ForMessage(18, global::Rochester.ARTable.Communication.Structure.Parser);
    private readonly pbc::RepeatedField<global::Rochester.ARTable.Communication.Structure> structures_ = new pbc::RepeatedField<global::Rochester.ARTable.Communication.Structure>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Rochester.ARTable.Communication.Structure> Structures {
      get { return structures_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as StructuresState);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(StructuresState other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Time != other.Time) return false;
      if(!structures_.Equals(other.structures_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Time != 0L) hash ^= Time.GetHashCode();
      hash ^= structures_.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Time != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(Time);
      }
      structures_.WriteTo(output, _repeated_structures_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Time != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(Time);
      }
      size += structures_.CalculateSize(_repeated_structures_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(StructuresState other) {
      if (other == null) {
        return;
      }
      if (other.Time != 0L) {
        Time = other.Time;
      }
      structures_.Add(other.structures_);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Time = input.ReadInt64();
            break;
          }
          case 18: {
            structures_.AddEntriesFrom(input, _repeated_structures_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
