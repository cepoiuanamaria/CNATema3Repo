vcpkg_from_github(
    OUT_SOURCE_PATH SOURCE_PATH
    REPO uNetworking/uWebSockets
    REF 588d234d45064fc70c0b6871383cbed2b6ff9d20 # v0.17.1
    SHA512 9fb5317e0b0877da737d331c5532eaac6c90e8e7fb38aff9f526ea36be98bbc59bb9dde856bcbd412c48c1703f095d981fe2aada6200df4c618ad2da4b68e9c0
    HEAD_REF master
)

file(COPY ${SOURCE_PATH}/src  DESTINATION ${CURRENT_PACKAGES_DIR}/include)
file(RENAME ${CURRENT_PACKAGES_DIR}/include/src ${CURRENT_PACKAGES_DIR}/include/uwebsockets/)

file(INSTALL ${SOURCE_PATH}/LICENSE DESTINATION ${CURRENT_PACKAGES_DIR}/share/${PORT} RENAME copyright)