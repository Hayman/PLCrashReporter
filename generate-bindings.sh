sdk='iphoneos9.1'

sharpie bind \
    plcrashreporter/CrashReporter.xcodeproj \
        -verbose \
        -sdk $sdk \
        -xcodeproj-target CrashReporter-iOS \
        -xcodeproj-config Release \
        -output . \
        -namespace CrashReporter \
        -c \
          -Ibuild
