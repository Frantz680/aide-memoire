# Event


```js
<script>
export default {
  mounted() {
    document.addEventListener('keydown', this.handleGlobalKeydown);
  },
  beforeUnmount() {
    document.removeEventListener('keydown', this.handleGlobalKeydown);
  },
  methods: {
    handleGlobalKeydown(event) {
      if (event.key === 'PageDown') {
        event.preventDefault(); // Arrête le comportement par défaut de la touche "Page suivante"
        // Autres actions à effectuer ici
      }
    }
  }
}
</script>
```