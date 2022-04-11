FROM grafana/grafana as ap-grafana
COPY ./config/grafana.ini /etc/grafana
COPY ./provisioning /etc/grafana/provisioning
COPY ./dashboard /var/lib/grafana/dashboard
EXPOSE 3000