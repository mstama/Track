@REM CREATE AND RUN THE DOCKER IMAGE SAMPLE
docker build . -f sample.dockerfile -t sample.track
docker run sample.track