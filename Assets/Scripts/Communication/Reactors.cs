// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: reactors.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Reactors {

  /// <summary>Holder for reflection information generated from reactors.proto</summary>
  public static partial class ReactorsReflection {

    #region Descriptor
    /// <summary>File descriptor for reactors.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ReactorsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg5yZWFjdG9ycy5wcm90bxIIcmVhY3RvcnMiQwoHUmVhY3RvchIKCgJpZBgB",
            "IAEoBRIMCgR0eXBlGAIgASgFEg4KBnhjb29yZBgDIAEoAhIOCgZ5Y29vcmQY",
            "BCABKAIiJQoLUmVhY3RvclBhaXISCgoCcjEYASABKAUSCgoCcjIYAiABKAUi",
            "ZgoNUmVhY3RvclN5c3RlbRIMCgR0aW1lGAEgASgDEiIKB3JlYWN0b3IYAiAD",
            "KAsyES5yZWFjdG9ycy5SZWFjdG9yEiMKBHBhaXIYAyADKAsyFS5yZWFjdG9y",
            "cy5SZWFjdG9yUGFpcmIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Reactors.Reactor), global::Reactors.Reactor.Parser, new[]{ "Id", "Type", "Xcoord", "Ycoord" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Reactors.ReactorPair), global::Reactors.ReactorPair.Parser, new[]{ "R1", "R2" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Reactors.ReactorSystem), global::Reactors.ReactorSystem.Parser, new[]{ "Time", "Reactor", "Pair" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Reactor : pb::IMessage<Reactor> {
    private static readonly pb::MessageParser<Reactor> _parser = new pb::MessageParser<Reactor>(() => new Reactor());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Reactor> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Reactors.ReactorsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Reactor() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Reactor(Reactor other) : this() {
      id_ = other.id_;
      type_ = other.type_;
      xcoord_ = other.xcoord_;
      ycoord_ = other.ycoord_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Reactor Clone() {
      return new Reactor(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private int id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    /// <summary>Field number for the "type" field.</summary>
    public const int TypeFieldNumber = 2;
    private int type_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Type {
      get { return type_; }
      set {
        type_ = value;
      }
    }

    /// <summary>Field number for the "xcoord" field.</summary>
    public const int XcoordFieldNumber = 3;
    private float xcoord_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Xcoord {
      get { return xcoord_; }
      set {
        xcoord_ = value;
      }
    }

    /// <summary>Field number for the "ycoord" field.</summary>
    public const int YcoordFieldNumber = 4;
    private float ycoord_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Ycoord {
      get { return ycoord_; }
      set {
        ycoord_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Reactor);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Reactor other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (Type != other.Type) return false;
      if (Xcoord != other.Xcoord) return false;
      if (Ycoord != other.Ycoord) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id != 0) hash ^= Id.GetHashCode();
      if (Type != 0) hash ^= Type.GetHashCode();
      if (Xcoord != 0F) hash ^= Xcoord.GetHashCode();
      if (Ycoord != 0F) hash ^= Ycoord.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Id);
      }
      if (Type != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Type);
      }
      if (Xcoord != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(Xcoord);
      }
      if (Ycoord != 0F) {
        output.WriteRawTag(37);
        output.WriteFloat(Ycoord);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Id);
      }
      if (Type != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Type);
      }
      if (Xcoord != 0F) {
        size += 1 + 4;
      }
      if (Ycoord != 0F) {
        size += 1 + 4;
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Reactor other) {
      if (other == null) {
        return;
      }
      if (other.Id != 0) {
        Id = other.Id;
      }
      if (other.Type != 0) {
        Type = other.Type;
      }
      if (other.Xcoord != 0F) {
        Xcoord = other.Xcoord;
      }
      if (other.Ycoord != 0F) {
        Ycoord = other.Ycoord;
      }
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
            Id = input.ReadInt32();
            break;
          }
          case 16: {
            Type = input.ReadInt32();
            break;
          }
          case 29: {
            Xcoord = input.ReadFloat();
            break;
          }
          case 37: {
            Ycoord = input.ReadFloat();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ReactorPair : pb::IMessage<ReactorPair> {
    private static readonly pb::MessageParser<ReactorPair> _parser = new pb::MessageParser<ReactorPair>(() => new ReactorPair());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ReactorPair> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Reactors.ReactorsReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReactorPair() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReactorPair(ReactorPair other) : this() {
      r1_ = other.r1_;
      r2_ = other.r2_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReactorPair Clone() {
      return new ReactorPair(this);
    }

    /// <summary>Field number for the "r1" field.</summary>
    public const int R1FieldNumber = 1;
    private int r1_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int R1 {
      get { return r1_; }
      set {
        r1_ = value;
      }
    }

    /// <summary>Field number for the "r2" field.</summary>
    public const int R2FieldNumber = 2;
    private int r2_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int R2 {
      get { return r2_; }
      set {
        r2_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ReactorPair);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ReactorPair other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (R1 != other.R1) return false;
      if (R2 != other.R2) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (R1 != 0) hash ^= R1.GetHashCode();
      if (R2 != 0) hash ^= R2.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (R1 != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(R1);
      }
      if (R2 != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(R2);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (R1 != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(R1);
      }
      if (R2 != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(R2);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ReactorPair other) {
      if (other == null) {
        return;
      }
      if (other.R1 != 0) {
        R1 = other.R1;
      }
      if (other.R2 != 0) {
        R2 = other.R2;
      }
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
            R1 = input.ReadInt32();
            break;
          }
          case 16: {
            R2 = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ReactorSystem : pb::IMessage<ReactorSystem> {
    private static readonly pb::MessageParser<ReactorSystem> _parser = new pb::MessageParser<ReactorSystem>(() => new ReactorSystem());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ReactorSystem> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Reactors.ReactorsReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReactorSystem() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReactorSystem(ReactorSystem other) : this() {
      time_ = other.time_;
      reactor_ = other.reactor_.Clone();
      pair_ = other.pair_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ReactorSystem Clone() {
      return new ReactorSystem(this);
    }

    /// <summary>Field number for the "time" field.</summary>
    public const int TimeFieldNumber = 1;
    private long time_;
    /// <summary>
    /// timestamp
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long Time {
      get { return time_; }
      set {
        time_ = value;
      }
    }

    /// <summary>Field number for the "reactor" field.</summary>
    public const int ReactorFieldNumber = 2;
    private static readonly pb::FieldCodec<global::Reactors.Reactor> _repeated_reactor_codec
        = pb::FieldCodec.ForMessage(18, global::Reactors.Reactor.Parser);
    private readonly pbc::RepeatedField<global::Reactors.Reactor> reactor_ = new pbc::RepeatedField<global::Reactors.Reactor>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Reactors.Reactor> Reactor {
      get { return reactor_; }
    }

    /// <summary>Field number for the "pair" field.</summary>
    public const int PairFieldNumber = 3;
    private static readonly pb::FieldCodec<global::Reactors.ReactorPair> _repeated_pair_codec
        = pb::FieldCodec.ForMessage(26, global::Reactors.ReactorPair.Parser);
    private readonly pbc::RepeatedField<global::Reactors.ReactorPair> pair_ = new pbc::RepeatedField<global::Reactors.ReactorPair>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Reactors.ReactorPair> Pair {
      get { return pair_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ReactorSystem);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ReactorSystem other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Time != other.Time) return false;
      if(!reactor_.Equals(other.reactor_)) return false;
      if(!pair_.Equals(other.pair_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Time != 0L) hash ^= Time.GetHashCode();
      hash ^= reactor_.GetHashCode();
      hash ^= pair_.GetHashCode();
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
      reactor_.WriteTo(output, _repeated_reactor_codec);
      pair_.WriteTo(output, _repeated_pair_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Time != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(Time);
      }
      size += reactor_.CalculateSize(_repeated_reactor_codec);
      size += pair_.CalculateSize(_repeated_pair_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ReactorSystem other) {
      if (other == null) {
        return;
      }
      if (other.Time != 0L) {
        Time = other.Time;
      }
      reactor_.Add(other.reactor_);
      pair_.Add(other.pair_);
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
            reactor_.AddEntriesFrom(input, _repeated_reactor_codec);
            break;
          }
          case 26: {
            pair_.AddEntriesFrom(input, _repeated_pair_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
