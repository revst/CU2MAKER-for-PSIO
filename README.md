

# CU2MAKER-for-PSIO
Simple utility to get correct .CU2 file for PSIO.

As you may know, an usual PSIO utility makes wrong .CU2 files for multi-track CDs.
That leads to incorrect beginning of playback music tracks in games.
Also .CU2 archived collections of files in internet contains the same errors.

My attempt is to create utility for correct processing of cd tracks.



Here are the steps to make .CU2 file:

1. Create new directory.
The name of new .CU2 file will be the same as new directory name.

2. Put cd tracks in .bin format (01 Track.bin, 02 Track.bin, xx Track.bin and next others) in that new directory.
Pay attention that "01 Track.bin" should be a "Data Track".
And "02 Track.bin and next others" should be a clean "Audio Tracks" (without 44bytes RIFF WAV header).

3. Put CU2MAKER.EXE in that new directory and start it.
Utility displays PREGAP time for each audio track.
To be sure output .CU2 file is right, please check redump.org for coincidence of PREGAP values.

4. Wait for processing and get .CU2 file.


