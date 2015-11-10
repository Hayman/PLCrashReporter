sharpie bind \
    plcrashreporter/CrashReporter.xcodeproj -v \
        -s iphoneos9.1 \
        -xcodeproj-target CrashReporter-iOS \
        -xcodeproj-config Release \
        -o . \
        -n CrashReporter \
        -c
          -Ibuild
