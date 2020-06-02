setlocal

set GRPC_PATH="D:\UNI\Anul2\Semestrul2\CNA\CNATema3Repo\Hello\Generated\grpc"
set PROTOC_PATH="D:\UNI\Anul2\Semestrul2\CNA\CNATema3Repo\Hello\Generated\protobuf"

set PROTOS_PATH=Protos
set OUTPUT_PATH=Generated

if not exist %OUTPUT_PATH% mkdir %OUTPUT_PATH%

for /R . %%f in (%PROTOS_PATH%\*.proto) do (
	%PROTOC_PATH%\protoc.exe --proto_path %PROTOS_PATH% --csharp_out %OUTPUT_PATH% %PROTOS_PATH%\%%~nf%%~xf 
)

for /R . %%f in (%PROTOS_PATH%%\*.proto) do (
	%PROTOC_PATH%\protoc.exe --proto_path %PROTOS_PATH% --grpc_out %OUTPUT_PATH% --plugin=protoc-gen-grpc=%GRPC_PATH%\grpc_csharp_plugin.exe %PROTOS_PATH%\%%~nf%%~xf
)

endlocal

pause