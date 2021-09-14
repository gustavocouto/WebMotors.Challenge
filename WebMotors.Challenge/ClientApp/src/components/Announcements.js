import React, { Component, useEffect, useState } from 'react';

export default function Announcements() {
  const [announcements, setAnnouncements] = useState([]);

  const reloadAnnouncements = async () => {
    fetch('announcements', { headers: { 'Content-Type': 'application/json', 'Accept': 'application/json' } })
      .then(_ => _.json())
      .then(_ => setAnnouncements(_));
  };

  const removeAnnouncement = async (id) => {
    fetch(`announcements/${id}`, { method: 'DELETE' })
      .then(() => reloadAnnouncements());
  };

  useEffect(() => {
    reloadAnnouncements();
  }, []);

  return (
    <div>
      <h1>Anúncios</h1>

      {announcements.map(announcement => <div key={announcement.id}
        style={{display: 'block', width: '100%', padding: '15px 0 15px 0', borderBottom: '1px solid gray'}}>
        <strong>Marca:</strong> {announcement.make}<br />
        <strong>Modelo:</strong> {announcement.model}<br />
        <strong>Versão:</strong> {announcement.version}<br />
        <strong>Ano:</strong> {announcement.year}<br />
        <strong>Quilometragem:</strong> {announcement.mileage}<br />
        <a href={`anuncios/${announcement.id}`}>Ver Mais</a> | <a href="#" onClick={() => removeAnnouncement(announcement.id)}>Remover</a>
      </div>)}
      {(!announcements || !announcements.length) && <p style={{textAlign: 'center', color: 'gray'}}>Nenhum anúncio</p>}
    </div>
  );
}