// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: chatRoom.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

public static partial class ChatService
{
  static readonly string __ServiceName = "ChatService";

  static readonly grpc::Marshaller<global::ChatMessage> __Marshaller_ChatMessage = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ChatMessage.Parser.ParseFrom);
  static readonly grpc::Marshaller<global::ChatMessageFromServer> __Marshaller_ChatMessageFromServer = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::ChatMessageFromServer.Parser.ParseFrom);

  static readonly grpc::Method<global::ChatMessage, global::ChatMessageFromServer> __Method_chat = new grpc::Method<global::ChatMessage, global::ChatMessageFromServer>(
      grpc::MethodType.DuplexStreaming,
      __ServiceName,
      "chat",
      __Marshaller_ChatMessage,
      __Marshaller_ChatMessageFromServer);

  /// <summary>Service descriptor</summary>
  public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
  {
    get { return global::ChatRoomReflection.Descriptor.Services[0]; }
  }

  /// <summary>Base class for server-side implementations of ChatService</summary>
  [grpc::BindServiceMethod(typeof(ChatService), "BindService")]
  public abstract partial class ChatServiceBase
  {
    public virtual global::System.Threading.Tasks.Task chat(grpc::IAsyncStreamReader<global::ChatMessage> requestStream, grpc::IServerStreamWriter<global::ChatMessageFromServer> responseStream, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

  }

  /// <summary>Client for ChatService</summary>
  public partial class ChatServiceClient : grpc::ClientBase<ChatServiceClient>
  {
    /// <summary>Creates a new client for ChatService</summary>
    /// <param name="channel">The channel to use to make remote calls.</param>
    public ChatServiceClient(grpc::ChannelBase channel) : base(channel)
    {
    }
    /// <summary>Creates a new client for ChatService that uses a custom <c>CallInvoker</c>.</summary>
    /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
    public ChatServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
    {
    }
    /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
    protected ChatServiceClient() : base()
    {
    }
    /// <summary>Protected constructor to allow creation of configured clients.</summary>
    /// <param name="configuration">The client configuration.</param>
    protected ChatServiceClient(ClientBaseConfiguration configuration) : base(configuration)
    {
    }

    public virtual grpc::AsyncDuplexStreamingCall<global::ChatMessage, global::ChatMessageFromServer> chat(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return chat(new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual grpc::AsyncDuplexStreamingCall<global::ChatMessage, global::ChatMessageFromServer> chat(grpc::CallOptions options)
    {
      return CallInvoker.AsyncDuplexStreamingCall(__Method_chat, null, options);
    }
    /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
    protected override ChatServiceClient NewInstance(ClientBaseConfiguration configuration)
    {
      return new ChatServiceClient(configuration);
    }
  }

  /// <summary>Creates service definition that can be registered with a server</summary>
  /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
  public static grpc::ServerServiceDefinition BindService(ChatServiceBase serviceImpl)
  {
    return grpc::ServerServiceDefinition.CreateBuilder()
        .AddMethod(__Method_chat, serviceImpl.chat).Build();
  }

  /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
  /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
  /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
  /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
  public static void BindService(grpc::ServiceBinderBase serviceBinder, ChatServiceBase serviceImpl)
  {
    serviceBinder.AddMethod(__Method_chat, serviceImpl == null ? null : new grpc::DuplexStreamingServerMethod<global::ChatMessage, global::ChatMessageFromServer>(serviceImpl.chat));
  }

}
#endregion