FROM python:3.7-alpine
WORKDIR /app
COPY . .
WORKDIR /app/src/
RUN pip3 install watchdog
ENTRYPOINT ["python3", "-u"]
CMD ["consumer.py", "../data/"]